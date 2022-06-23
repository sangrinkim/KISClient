using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KISClient.Core.Model
{
    public class StockLastPriceModel : BaseModel
    {
        [JsonProperty("stck_prpr")]
        public string LastPrice { get; set; }
    }
}
