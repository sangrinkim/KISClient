using System;
using System.Collections.Generic;
using System.Text;

namespace KISClient.Core.Model
{
    public class AccessTokenModel : BaseModel
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public string ExpireSec { get; set; }
    }
}
