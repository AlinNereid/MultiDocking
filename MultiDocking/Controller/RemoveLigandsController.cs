using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog;

namespace MultiDocking.Controller
{
    public class RemoveLigandsController : AController
    {
        private Logger _logger = LogManager.GetCurrentClassLogger();

        static readonly List<string> TokenNotInLine = new List<string>() { "ANISOU", "HETATM", "CONECT" };
        static bool LineIsFine(string line)
        {
            foreach (var n in TokenNotInLine)
            {
                if (line.StartsWith(n))
                    return false;
            }

            return true;
        }

        private void ProcessFile(string inputPath, string outputPath)
        {
            var n = File.ReadAllLines(inputPath).Where(LineIsFine).ToList();

            File.WriteAllLines(outputPath, n);
        }

        public void RemoveLigands(List<FileInfo> files, string outputFolder, Action<int, string> onRefreshAction, Action onFinish, Func<bool> abortFunc)
        {
            _logger.Debug("Remove Ligands");
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);
            StartEta(files.Count, onRefreshAction);

            foreach (var file in files)
            {
                _logger.Debug($"Process {file.Name}");
                Controllers.RemoveLigandsController.ProcessFile(file.FullName, Path.Combine(outputFolder, file.Name));
                if (abortFunc != null)
                {
                    if (abortFunc.Invoke() == true)
                    {
                        break;
                    }
                }
                AddOneProcessedItemAndRefreshEta();
            }
            onFinish?.Invoke();
        }
    }
}
