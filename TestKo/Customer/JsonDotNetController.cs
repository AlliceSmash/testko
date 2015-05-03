using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;


namespace TestKo.Customer
{
    public class JsonDotNetResult : JsonResult
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Converters = new List<JsonConverter> { new StringEnumConverter() }
        };

        public override void ExecuteResult(ControllerContext context)
        {
            if (this.JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("GET request not allowed");
            }

            var response = context.HttpContext.Response;

            response.ContentType = !string.IsNullOrEmpty(this.ContentType) ? this.ContentType : "application/json";

            if (this.ContentEncoding != null)
            {
                response.ContentEncoding = this.ContentEncoding;
            }

            if (this.Data == null)
            {
                return;
            }

            response.Write(JsonConvert.SerializeObject(this.Data, Settings));
        }
    }
    public class JsonDotNetController : Controller
    {
        public JsonDotNetResult JsonDotNet(object data)
        {
            return JsonDotNet(data, null, null, JsonRequestBehavior.DenyGet);
        }

        public JsonDotNetResult JsonDotNet(object data,
            JsonRequestBehavior jsonRequestBehavior)
        {
            return JsonDotNet(data, null, null, jsonRequestBehavior);
        }

        public static JsonDotNetResult JsonDotNet(object data,
            string contentType,
            Encoding contentEncoding,
            JsonRequestBehavior jsonRequestBehavior)
        {
            return new JsonDotNetResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = jsonRequestBehavior
            };
        }

        protected string JsonModelStateErrors
        {
            get
            {
                var messageDictionary = ModelState
                    .ToDictionary(
                        d => d.Key,
                        d => d.Value.Errors.Select(e => e.ErrorMessage));

                var messages =
                    messageDictionary.Where(de => de.Value.Any())
                        .SelectMany(m => m.Value, (a, b) => new KeyValuePair<string, string>(a.Key, b));
                var json = JsonConvert.SerializeObject(messages);
                return json;
            }
        }
    }
}