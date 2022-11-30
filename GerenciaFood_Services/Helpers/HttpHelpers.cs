using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaFood_Services.Helpers
{
    public static class HttpHelpers
    {
        public static async Task<T> Deserialize<T>(HttpResponseMessage response)
        {
            var content = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(content,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
        }

        public static HttpContent GetHttpContent(this object obj)
        {
            HttpContent httpContent;
            var objSerialized = JsonConvert.SerializeObject(obj);

            httpContent = new StringContent(objSerialized, Encoding.UTF8, "application/json");
            return httpContent;
        }

    }
}
