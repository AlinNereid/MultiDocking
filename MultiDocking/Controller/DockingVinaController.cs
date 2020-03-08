using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CliWrap;
using NLog;

namespace MultiDocking.Controller
{
    class DockingVinaController : AController
    {
        class CalculateCube
        {
            public string Calculate(string file)
            {
                var lines = File.ReadAllLines(file);

                var atomLines = new List<string>();
                foreach (var line in lines)
                {
                    if (line.StartsWith("ATOM"))
                    {
                        atomLines.Add(line);
                    }
                }

                var xList = new List<double>();
                var yList = new List<double>();
                var zList = new List<double>();

                foreach (var atomLine in atomLines)
                {
                    var xString = atomLine.Substring(30, 8);
                    var yString = atomLine.Substring(38, 8);
                    var zString = atomLine.Substring(46, 8);

                    xList.Add(Convert.ToDouble(xString));
                    yList.Add(Convert.ToDouble(yString));
                    zList.Add(Convert.ToDouble(zString));
                }

                var xMax = xList.Max();
                var yMax = yList.Max();
                var zMax = zList.Max();

                var xMin = xList.Min();
                var yMin = yList.Min();
                var zMin = zList.Min();

                var sb = new StringBuilder();

                double centerX = Math.Round((xMin + xMax) / 2, 3);
                double centerY = Math.Round((yMin + yMax) / 2, 3);
                double centerZ = Math.Round((zMin + zMax) / 2, 3);

                double sizeX = Math.Abs(xMax - xMin);
                double sizeY = Math.Abs(yMax - yMin);
                double sizeZ = Math.Abs(zMax - zMin);

                sb.AppendLine($"center_x = {centerX}");
                sb.AppendLine($"center_y = {centerY}");
                sb.AppendLine($"center_z = {centerZ}");
                sb.AppendLine();
                sb.AppendLine($"size_x = {sizeX}");
                sb.AppendLine($"size_y = {sizeY}");
                sb.AppendLine($"size_z = {sizeZ}");

                return sb.ToString();
            }
        }

        private Logger _logger = LogManager.GetCurrentClassLogger();

        private string CreateConfigFile(FileInfo protein, string ligandName)
        {
            var sb = new StringBuilder($"ligand = {ligandName}\r\n");
            sb.AppendLine($"receptor = {protein.Name}\r\n");
            var size = new CalculateCube().Calculate(protein.FullName);
            sb.AppendLine(size);
            sb.AppendLine($"num_modes = {Settings.Default.NumModes}");
            sb.AppendLine($"exhaustiveness = {Settings.Default.Exhaustiveness}");
            return sb.ToString();
        }

        private void LetOnlyFirstMer(string filePath)
        {
            var fileContent = File.ReadAllText(filePath);
            var count = Regex.Matches(fileContent, "TER").Count;

            if (count > 1)
            {
                var indexOfFirstTer = fileContent.IndexOf("TER");

                var newContent = fileContent.Substring(0, fileContent.IndexOf("\n", indexOfFirstTer) + 1);
                File.WriteAllText(filePath, newContent);
            }
        }

        public void RunVina(List<FileInfo> files, string outputFolder, string ligandPath, bool firstMer,
            int numberOfDockingRuns, Action<int, string> onRefreshAction, Action onFinish, Func<bool> abortFunc)
        {
            string tempFolder = Path.Combine(outputFolder, "temp");
            if (!Directory.Exists(tempFolder))
                Directory.CreateDirectory(tempFolder);
            var start = DateTime.Now;
            StartEta(files.Count * numberOfDockingRuns, onRefreshAction);
            _logger.Debug("Run Vina");
            foreach (var fileInfo in files)
            {
                _logger.Debug($"Process {fileInfo.Name}");
                for (int run = 0; run < numberOfDockingRuns; run++)
                {
                    try
                    {
                        Directory.Delete(tempFolder, true);
                        Directory.CreateDirectory(tempFolder);
                        var ligandFileInfo = new FileInfo(ligandPath);
                        File.Copy(ligandPath, Path.Combine(tempFolder, ligandFileInfo.Name));
                        File.Copy(fileInfo.FullName, Path.Combine(tempFolder, fileInfo.Name));
                        if (firstMer)
                        {
                            LetOnlyFirstMer(Path.Combine(tempFolder, fileInfo.Name));
                        }

                        File.WriteAllText(Path.Combine(tempFolder, "config.txt"),
                            CreateConfigFile(fileInfo, ligandFileInfo.Name));
                        try
                        {

                            var startTimeForProcess = DateTime.Now;
                            var cli = Cli.Wrap(Settings.Default.VinaPath)
                                .SetWorkingDirectory(tempFolder)
                                .SetArguments(
                                    "--config " + "config.txt")
                                .SetStandardOutputCallback(l =>
                                    Console.WriteLine($"StdOut> {l}")) // triggered on every line in stdout
                                .Execute();

                            var res = cli.ExitCode;

                            File.WriteAllText(Path.Combine(tempFolder, "vina_output.txt"),
                                cli.StandardOutput + "\r\n" + "Duration (seconds): " +
                                (DateTime.Now - startTimeForProcess).TotalSeconds);
                            if (res == 0)
                            {
                                if (run == 0)
                                {
                                    File.Move(
                                        Path.Combine(tempFolder, ligandFileInfo.Name.Replace(".pdbqt", "_out.pdbqt")),
                                        Path.Combine(outputFolder, fileInfo.Name + "_docking_" + ligandFileInfo.Name));
                                    File.Move(Path.Combine(tempFolder, "vina_output.txt"),
                                        Path.Combine(outputFolder, fileInfo.Name + "_result.txt"));
                                }
                                else
                                {
                                    File.Move(
                                        Path.Combine(tempFolder, ligandFileInfo.Name.Replace(".pdbqt", "_out.pdbqt")),
                                        Path.Combine(outputFolder,
                                            fileInfo.Name + $"_run{run + 1}_docking_" + ligandFileInfo.Name));
                                    File.Move(Path.Combine(tempFolder, "vina_output.txt"),
                                        Path.Combine(outputFolder, fileInfo.Name + $"_run{run + 1}_result.txt"));
                                }
                            }

                        }
                        catch (Exception e)
                        {
                            _logger.Error(e);
                        }

                        if (abortFunc != null)
                        {
                            if (abortFunc.Invoke() == true)
                            {
                                goto Finish;
                            }
                        }

                        AddOneProcessedItemAndRefreshEta();
                    }

                    catch (Exception e)
                    {
                        _logger.Error(e);
                    }
                }
            } 
            
            Finish:
            onFinish?.Invoke();
        }
    }
}
