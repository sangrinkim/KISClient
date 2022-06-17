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
    }
}
