using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;

namespace Dictionary.Api.App_Start
{
    public class FormatterConfig
    {
        public static void Format(MediaTypeFormatterCollection formatters)
        {
            var settings = formatters.JsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}