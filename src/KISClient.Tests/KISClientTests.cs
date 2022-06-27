using KISClient.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace KISClient.Tests
{
    public class KISClientTests
    {
        KISHttpClient client;

        public KISClientTests()
        {
            string appkey = "your appkey";
            string appsecret = "your appsecret";

            client = new KISHttpClient(appkey, appsecret);
        }

        [Fact]
        public void GetHashkeyTest()
        {
            bool result = client.GetHashKey("your account no");

            // Expected: True
            Assert.True(result, "Failed to get hashkey");
        }

        [Fact]
        public void GetAccessTokenTest()
        {
            bool result = client.GetAccessToken();

            Assert.True(result, "Failed to get access token");
        }

        [Fact]
        public void RevokeTokenTest()
        {
            bool gotToken = client.GetAccessToken();
            if (gotToken == true)
            {
                bool result = client.RevokeToken();

                Assert.True(result, "Failed to revoke token");
            }
        }

        [Fact]
        public void GetStockPriceTest()
        {
            GetAccessTokenTest();

            var result = client.GetStockPrice("009150");
            string test = string.Format("{0}: {1}, {2}", result.Output.StockCode, result.Output.LastPrice, result.Output.ChangeRate);
            // result 009150: 135000, 3.05

            Assert.True(result != null, test);
        }
    }
}
