using System.Collections.Generic;
using Newtonsoft.Json;

namespace VaultSharp.V1.AuthMethods.CloudFoundry.Models
{
    public class RoleList
    {
        [JsonProperty("keys")]
        public List<string> Keys { get; set; }
    }
}