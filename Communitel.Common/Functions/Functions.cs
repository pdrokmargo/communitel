using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Communitel.Common.Functions
{
    public class Functions
    {
        public static bool IsPropertyExist(dynamic settings, string name)
        {
            bool isDefined = false;

            if (settings is Newtonsoft.Json.Linq.JObject)
                isDefined = ((Newtonsoft.Json.Linq.JObject)settings).Property(name) != null;
            else
                isDefined = ((IDictionary<string, object>)settings).ContainsKey(name);
            return isDefined;
        }

        public static StreamContent CreateFileContent(Stream stream, string fileName,string fieldName ,string contentType)
        {
            var fileContent = new StreamContent(stream);
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = $"\"{fieldName}\"",
                FileName = "\"" + fileName + "\""
            }; // the extra quotes are key here
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            return fileContent;
        }
    }
}
