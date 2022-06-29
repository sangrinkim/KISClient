using System.Text.Json.Serialization;
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
        [JsonPropertyName("rt_cd")]
        public string IsSuccessful { get; set; }

        [JsonPropertyName("msg_cd")]
        public string MessageCode { get; set; }

        [JsonPropertyName("msg1")]
        public string Message { get; set; }

        [JsonPropertyName("output")]
        public T Output { get; set; }
    }
}
