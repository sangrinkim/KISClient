using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace KISClient.Core.Model
{
    public class HashkeyModel
    {
        [JsonPropertyName("HASH")]
        public string Key { get; set; }
    }
}
