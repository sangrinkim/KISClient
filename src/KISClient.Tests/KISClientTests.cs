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
            string appkey = "PSSoSpLRLxRWUiei2Wg0nHITiVkzAvzA9ru1";
            string appsecret = "2K4ye093wkZpB29RYCk6l54nYFmDaiR/5pUvBLE0oTjDxtVjfScwa2imWe57Lz+SUwriLc/uO3zQyCIX57J9cqwPQMhya+5NGrP2QR8WN8FqVK4mwyX/jiBtvFGuU3Y+Lc5DRR7V3E9w7gUjKQN/gnkUe2K4RtngrtHCnJOGizttCVkazu8=";
            client = new KISHttpClient(appkey, appsecret);
        }

        [Fact]
        public void GetHashkeyTest()
        {
            bool result = client.GetHashKey("your account no");

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
    }
}
