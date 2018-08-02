using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Sigga.Avaliacao.Common
{
    public static class Dynamic
    {
        public static object JObject { get; private set; }

        public static IDictionary<string, string> ExtractProperties(dynamic entity)
        {
            var response = new Dictionary<string, string> { };

            var json = entity as JObject;
            var dictionary = json.ToObject<IDictionary<string, object>>();

            foreach (var property in dictionary)
            {
                if (property.Value is JObject)
                {
                    var collection = ExtractProperties(property.Value);

                    foreach (var item in collection)
                        response.Add(item.Key, item.Value);

                    continue;
                }

                response.Add(property.Key, property.Value.ToString());
            }

            return response;
        }
    }
}
