using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Acts29Torch.WEB.Helper
{
    public class ApiHelper
    {
        private readonly static string ApiUrl = ConfigurationManager.AppSettings["ApiUrl"];

        public  async Task<TR> Post<TR,TS>(string strUrl, TS tData)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                StringContent content = new StringContent(JsonConvert.SerializeObject(tData), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(strUrl, content);
                string responseBody = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<TR>(responseBody);
            }
        }

        public  async Task<TR> Get<TR>(string strUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(strUrl);
                string responseBody = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<TR>(responseBody);
            }
        }
    }
}