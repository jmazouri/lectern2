using System;
using Newtonsoft.Json;

namespace Lectern2.Util
{
    public static class JsonUtil
    {
        public static string ToJson(Object obj, bool indented = true)
        {
            return JsonConvert.SerializeObject(obj, (indented ? Formatting.Indented : Formatting.None));
        }
    }
}
