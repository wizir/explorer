using Newtonsoft.Json;

namespace explorer.Utils
{
    public static class JsonEstensions
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        } 
    }
}