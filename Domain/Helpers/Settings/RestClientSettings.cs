using RestSharp;
using System.Collections.Generic;

namespace Domain.Helpers.Settings
{
    public class RestClientSettings
    {
        public string Endpoint { get; set; }
        public Method Method { get; set; }
        public object Payload { get; set; }
        public Dictionary<string, string> QueryStringParameters { get; set; }
    }
}
