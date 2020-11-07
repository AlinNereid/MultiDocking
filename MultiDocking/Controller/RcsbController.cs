using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;

namespace MultiDocking.Controller
{
    public class RcsbController : AController
    {
        private Logger _logger = LogManager.GetCurrentClassLogger();

        public async Task<List<string>> GetPdbId(string keyword)
        {
            const string url = "http://search.rcsb.org/rcsbsearch/v1/query";
            var httpClient = new HttpClient();
            var jsonTemplate =
                $"?json=%7B\"query\":%7B\"type\":\"terminal\",\"service\":\"text\",\"parameters\":%7B\"value\":\"{keyword}\"%7D%7D,\"return_type\":\"entry\",\"request_options\":%7B\"pager\":%7B\"start\":0,\"rows\":10000%7D%7D%7D";
            var response = await httpClient.GetAsync(url+jsonTemplate);
            var responseString = await response.Content.ReadAsStringAsync();

            var json = JObject.Parse(responseString);

            var pdbIds = new List<string>();

            foreach (var result in json["result_set"])
            {
                var identified = result["identifier"];
                pdbIds.Add(identified.ToString());
            }

            pdbIds.Sort();

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
                        client.DownloadFile("http://files.rcsb.org/download/" + pdbName, Path.Combine(path, pdbName));
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
