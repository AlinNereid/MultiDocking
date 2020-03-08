using System;
using System.Collections.Generic;
using System.IO;
using CliWrap;
using NLog;

namespace MultiDocking.Controller
{
    public class PrepareReceptorController : AController
    {
        private Logger _logger = LogManager.GetCurrentClassLogger();

        public void PdbToPdbqtFolder(List<string> files, string inputFolder, string outputFolder, Action<int, string> onRefreshAction,
            Action onFinish = null, Func<bool> abortFunc = null)
        {
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);
            StartEta(files.Count, onRefreshAction);
            _logger.Debug("PdbToPdbqtFolder");
            foreach (var file in files)
            {
                var fi = new FileInfo(file);
                if (fi.Name.EndsWith("pdb"))
                {
                    _logger.Debug($"Process {fi.Name}");
                    try
                    {
                        var cli = Cli.Wrap(Settings.Default.MGLToolsPython)
                            .SetWorkingDirectory(inputFolder)
                            .SetArguments(
                                $"{Settings.Default.PrepareReceptortScript} -r " +
                                fi.Name)
                            .SetStandardOutputCallback(l =>
                                Console.WriteLine($"StdOut> {l}")) // triggered on every line in stdout
                            .Execute();
                        File.Move(fi.FullName.Replace(".pdb",".pdbqt"),Path.Combine(outputFolder, fi.Name).Replace(".pdb", ".pdbqt"));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        _logger.Error(e);
                    }

                    if (abortFunc != null)
                    {
                        if (abortFunc.Invoke() == true)
                        {
                            break;
                        }
                    }
                }
                AddOneProcessedItemAndRefreshEta();
            }

            onFinish?.Invoke();
        }
    }
}
