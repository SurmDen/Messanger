using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;

namespace UserManager.Helpers
{
    public class Sender
    {
        public static async Task<HttpResponseMessage> PostAsync(Dictionary<string, string> postObject, string url)
        {
            HttpClient client = new HttpClient();

            HttpContent encodedContent = new FormUrlEncodedContent(postObject);

            HttpResponseMessage response = await client.PostAsync(url, encodedContent);

            return response;
        }

        public static async Task<string> GetAsync(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string answer = string.Empty;

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    answer = await reader.ReadToEndAsync();
                }
            }

            return answer;
        }
    }
}
