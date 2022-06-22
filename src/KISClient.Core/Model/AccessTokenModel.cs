using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace KISClient.Core.Model
{
    public class AccessTokenModel : BaseModel
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        public string GetAuthorizationString()
        {
            return string.Format("{0} {1}", this.TokenType, this.AccessToken);
        }
    }
}
