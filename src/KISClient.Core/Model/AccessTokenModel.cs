using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace KISClient.Core.Model
{
    public class AccessTokenModel : BaseModel
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        public string GetAuthorizationString()
        {
            return string.Format("{0} {1}", this.TokenType, this.AccessToken);
        }
    }
}
