using System;

namespace KISClientConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KISClient client = new KISClient("your appkey"
                , "your appsecret");

            client.GetHashKey("your accunt number");
            client.GetAccessToken();
            //client.RevokeToken();

            client.GetStockPrice("000660");
        }
    }
}