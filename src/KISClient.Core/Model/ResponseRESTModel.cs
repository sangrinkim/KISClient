using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KISClient.Core.Model
{
    public class ResponseRESTModel<T> : BaseModel
    {
        /// <summary>
        /// 0: Success
        /// other: Failure
        /// </summary>
        [JsonProperty("rt_cd")]
        public string IsSuccessful { get; set; }

        [JsonProperty("msg_cd")]
        public string MessageCode { get; set; }

        [JsonProperty("msg1")]
        public string Message { get; set; }

        [JsonProperty("output")]
        public T Output { get; set; }
    }
}
