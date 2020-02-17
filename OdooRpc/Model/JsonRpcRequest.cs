using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SalesApp.OdooRpc.Model
{
    class JsonRpcRequestParameter
    {
        [JsonProperty(PropertyName = "method")]
        public string Method { get; set; }

        [JsonProperty(PropertyName = "service")]
        public string Service { get; set; }

        [JsonProperty(PropertyName = "args")]
        public object[] Argument { get; set; }

        public JsonRpcRequestParameter(string service, string method, object[] args)
        {
            this.Service = service;
            this.Method = method;
            this.Argument = args;
        }

        public JsonRpcRequestParameter(string service, string method) : this(service, method, new object[] { }) { }
    }

    class JsonRpcRequest
    {
        [JsonProperty(PropertyName = "jsonrpc")]
        public string JsonRpcVersion { get; set; }

        [JsonProperty(PropertyName = "method")]
        public string Method { get; set; }

        [JsonProperty(PropertyName = "params")]
        public JsonRpcRequestParameter Parameter { get; set; }

        public JsonRpcRequest(JsonRpcRequestParameter parameter)
        {
            this.JsonRpcVersion = "2.0";
            this.Method = "call";
            this.Parameter = parameter;
        }
    }
}
