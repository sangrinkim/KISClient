using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KISClient.Core.Model
{
    public class StockLastPriceModel : BaseModel
    {
        [JsonProperty("stck_shrn_iscd")]
        public string StockCode { get; set; }

        [JsonProperty("stck_prpr")]
        public string LastPrice { get; set; }

        [JsonProperty("prdy_ctrt")]
        public string ChangeRate { get; set; }
    }
}
