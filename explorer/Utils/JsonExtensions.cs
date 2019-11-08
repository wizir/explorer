using System.Collections.Generic;
using explorer.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace explorer.Utils
{
    public static class JsonEstensions
    {
        public static string ToJson(this DatabaseObject obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        } 
        public static string ToJson(this IEnumerable<DatabaseObject> obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        } 
    }
}