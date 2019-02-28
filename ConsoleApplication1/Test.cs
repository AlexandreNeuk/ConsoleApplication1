using SyncProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Test
    {
        private SyncProcess _sync = new SyncProcess();
        private static HttpClient _httpClient = new HttpClient();
        private Thread _thread;

        public Test()
        {
            Start();
        }

        private void Start()
        {
            SyncProcess _sync = new SyncProcess();
            //
            Register(new Random().Next(0, 32000), "");
            _sync.OnComplete += ImportComplete;
            //
            _thread = new Thread(() =>
            {
                try
                {
                    _sync.Run();
                }
                catch (Exception ex)
                {

                }
            });
            //
            _thread.Start();
        }

        private void ImportComplete()
        {
            try
            {
                //GeraEmail();
                //     
                Register(1, "");
                System.Threading.Thread.Sleep(10000);
            }
            catch (Exception e)
            {

            }
        }

        public async void Register(int idsync, string type)
        {
            try
            {
                string url = "https://en.wikipedia.org/wiki/";
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Category:", "HTTP_clients")
                });
                var response = await _httpClient.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    // do something
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
