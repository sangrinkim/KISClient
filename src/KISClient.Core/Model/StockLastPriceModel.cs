using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace KISClient.Core.Model
{
    public class StockLastPriceModel : BaseModel
    {
        [JsonPropertyName("stck_shrn_iscd")]
        public string StockCode { get; set; }

        [JsonPropertyName("stck_prpr")]
        public string LastPrice { get; set; }

        [JsonPropertyName("prdy_ctrt")]
        public string ChangeRate { get; set; }
    }
}
