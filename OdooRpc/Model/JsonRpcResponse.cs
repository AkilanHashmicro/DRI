using Newtonsoft.Json;

namespace SalesApp.OdooRpc.Model
{
    class JsonRpcResponse<T>
    {
        [JsonProperty(PropertyName = "jsonrpc")]
        public string JsonRpcVersion { get; set; }

        [JsonProperty(PropertyName = "result")]
        public T Result { get; set; }

        [JsonProperty(PropertyName = "error")]
        public ResponseError Error { get; set; }
    }

    class ResponseError
    {
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "data")]
        public ErrorData Data { get; set; }
    }

    class ErrorData
    {
        [JsonProperty(PropertyName = "debug")]         
        public string Debug { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "arguments")]
        public string[] Arguments { get; set; }
    }


}
