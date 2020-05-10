using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace MultiDocking.Controller
{
    public class RcsbController : AController
    {
        private Logger _logger = LogManager.GetCurrentClassLogger();

        public async Task<List<string>> GetPdbId(string keyword)
        {
            const string url = "http://www.rcsb.org/pdb/rest/search/";
            var httpClient = new HttpClient();
            var xmlTemplate =
                $"<orgPdbQuery><queryType>org.pdb.query.simple.AdvancedKeywordQuery</queryType><keywords>{keyword}</keywords></orgPdbQuery>";
            var response = await httpClient.PostAsync(url,
                new StringContent(xmlTemplate, Encoding.UTF8, "application/x-www-form-urlencoded"));
            var responseString = await response.Content.ReadAsStringAsync();

            var pdbIds = new List<string>();
            foreach (var pdbId in responseString.Split(Environment.NewLine.ToCharArray()))
            {
                if (!string.IsNullOrEmpty(pdbId))
                    pdbIds.Add(pdbId);

            }

            return pdbIds;
        }

        public void Download(string path, List<string> pdbIds, Action<int, string> onRefreshAction,
            Action onFinish = null, Func<bool> abortFunc = null)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            _logger.Debug("Download Rcsb, count = " + pdbIds.Count);
            StartEta(pdbIds.Count, onRefreshAction);
            foreach (var pdbId in pdbIds)
            {
                using (var client = new WebClient())
                {
                    var pdbName = pdbId + ".pdb";
                    _logger.Debug("Download " + pdbName);
                    try
                    {
                        client.DownloadFile("https://files.rcsb.org/download/" + pdbName, Path.Combine(path, pdbName));
                    }
                    catch (Exception e)
                    {
                        _logger.Error(e);
                    }

                    if (abortFunc != null)
                    {
                        if (abortFunc.Invoke() == true)
                        {
                            break;
                        }
                    }
                    AddOneProcessedItemAndRefreshEta();
                }
            }
            onFinish?.Invoke();
        }
    }
}
