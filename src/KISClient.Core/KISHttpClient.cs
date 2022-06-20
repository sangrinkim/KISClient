using KISClient.Core.Model;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace KISClient.Core
{
    /// <summary>
    /// References: 
    /// https://apiportal.koreainvestment.com/intro
    /// https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=netcore-3.1
    /// https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
    /// </summary>
    public class KISHttpClient
    {
        private readonly string REAL_SERVER_URL = @"https://openapi.koreainvestment.com:9443/";
        private static readonly HttpClient Client = new HttpClient();

        private string Hashkey;
        //private string AccessToken;
        private AccessTokenModel AccessToken;

        private string Appkey;
        private string Appsecret;

        
        public KISHttpClient(string appkey, string appsecret)
        {
            this.Appkey = appkey;
            this.Appsecret = appsecret;

            Client.BaseAddress = new Uri(REAL_SERVER_URL);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public bool GetHashKey(string accountNo)
        {
            Client.DefaultRequestHeaders.Add("appkey", this.Appkey);
            Client.DefaultRequestHeaders.Add("appsecret", this.Appsecret);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/uapi/hashkey");
            request.Content = new StringContent($"{{\"CANO\":\"{ accountNo }\", \"ACNT_PRDT_CD\":\"01\", \"OVRS_EXCG_CD\":\"SHAA\"}}",
                                                Encoding.UTF8);

            HttpResponseMessage response = Client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                string resonseString = response.Content.ReadAsStringAsync().Result;
                var responseData = (JObject)JsonConvert.DeserializeObject(resonseString);
                this.Hashkey = responseData["HASH"].Value<string>();

                return true;
            }

            return false;
        }

        public bool GetAccessToken()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/oauth2/tokenP");
            request.Content = new StringContent($"{{\"grant_type\":\"client_credentials\", \"appkey\":\"{ this.Appkey }\", \"appsecret\":\"{ this.Appsecret }\"}}",
                                                Encoding.UTF8);

            HttpResponseMessage response = Client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                this.AccessToken = JsonConvert.DeserializeObject<AccessTokenModel>(responseString);

                return true;
            }

            return false;
        }

        public bool RevokeToken()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/oauth2/revokeP");
            request.Content = new StringContent($"{{\"appkey\":\"{ this.Appkey }\", \"appsecret\":\"{ this.Appsecret }\", \"token\":\"{ this.AccessToken }\"}}",
                                                Encoding.UTF8);

            HttpResponseMessage response = Client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                string resonseString = response.Content.ReadAsStringAsync().Result;
                var responseData = (JObject)JsonConvert.DeserializeObject(resonseString);

                return responseData["code"].ToString() == "200";
            }

            return false;
        }

        public void GetStockPrice(string stockCode)
        {
            Dictionary<string, string> paramDic = new Dictionary<string, string>();
            paramDic.Add("FID_COND_MRKT_DIV_CODE", "J");
            paramDic.Add("FID_INPUT_ISCD", stockCode);

            var combinedUriString = QueryHelpers.AddQueryString(REAL_SERVER_URL + "uapi/domestic-stock/v1/quotations/inquire-price", paramDic);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(combinedUriString));
            request.Content = new StringContent("", Encoding.UTF8, "application/json");
            request.Headers.Add("authorization", "Bearer " + this.AccessToken);
            request.Headers.Add("appkey", this.Appkey);
            request.Headers.Add("appsecret", this.Appsecret);
            request.Headers.Add("tr_id", "FHKST01010100");

            HttpResponseMessage response = Client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                string resonseString = response.Content.ReadAsStringAsync().Result;

                Console.WriteLine(resonseString);
            }
            else
            {
                Console.WriteLine("Fail: {0}", response.StatusCode);
            }
        }
    }
}
