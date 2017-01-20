using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Communitel.Common.Helpers
{
    public class ServiceRequest
    {

        public ServiceRequest()
        { }

        //public Task<dynamic> GET(string requestUri, Dictionary<string, object> headers = null)
        //{
        //    if (requestUri == null)
        //    {
        //        throw new ArgumentNullException("RequestUri");
        //    }

        //    var http = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["baseURL"] + requestUri));
        //    http.Method = "GET";
        //    http.ContentType = "application/json";
        //    http.Accept = "application/json";
        //    http.Headers["Authorization"] = "Bearer " + Variables.Token;

        //    if (headers != null && headers.Count > 0)
        //        foreach (var item in headers)
        //            http.Headers[item.Key] = item.Value.ToString();


        //    var response = http.GetResponse();
        //    var stream = response.GetResponseStream();
        //    var sr = new StreamReader(stream);
        //    var content = sr.ReadToEnd();
        //    dynamic magic = JsonConvert.DeserializeObject(content);
        //    return magic;
        //}

        public async Task<dynamic> requestToken(string oauthUri, string parsedContent)
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["baseURL"] + oauthUri));
            http.ContentType = "application/x-www-form-urlencoded";
            http.Method = "POST";

            ASCIIEncoding encoding = new ASCIIEncoding();
            if (parsedContent != "")
            {
                Byte[] bytes = encoding.GetBytes(parsedContent);
                Stream newStream = http.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();
            }

            var response = await http.GetResponseAsync();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = await sr.ReadToEndAsync();
            dynamic magic = JsonConvert.DeserializeObject(content);
            return magic;
        }

        public async Task<dynamic> GET(string requestUri)
        {
            if (requestUri == null)
            {
                throw new ArgumentNullException("RequestUri");
            }

            var http = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["baseURL"] + requestUri));
            http.Method = "GET";
            http.ContentType = "application/json";
            http.Accept = "application/json";
            http.Headers["Authorization"] = "Bearer " + Variables.Token;

            var response = await http.GetResponseAsync();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = await sr.ReadToEndAsync();
            dynamic magic = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject(content));
            return magic;
        }

        public async Task<dynamic> GET(string requestUri, Dictionary<string, object> headers = null)
        {
            if (requestUri == null)
            {
                throw new ArgumentNullException("RequestUri");
            }

            var http = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["baseURL"] + requestUri));
            http.Method = "GET";
            http.ContentType = "application/json";
            http.Accept = "application/json";
            http.Headers["Authorization"] = "Bearer " + Variables.Token;

            if (headers != null && headers.Count > 0)
                foreach (var item in headers)
                    http.Headers[item.Key] = item.Value.ToString();


            var response = await http.GetResponseAsync();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = await sr.ReadToEndAsync();
            dynamic magic = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject(content));
            return magic;
        }

        public async Task<T> GET<T>(string requestUri, Dictionary<string, object> headers = null)
        {
            if (requestUri == null)
            {
                throw new ArgumentNullException("RequestUri");
            }

            var http = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["baseURL"] + requestUri));
            http.Method = "GET";
            http.ContentType = "application/json";
            http.Accept = "application/json";
            http.Headers["Authorization"] = "Bearer " + Variables.Token;

            if (headers != null && headers.Count > 0)
                foreach (var item in headers)
                    http.Headers[item.Key] = item.Value.ToString();


            var response = await http.GetResponseAsync();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = await sr.ReadToEndAsync();
            T magic = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(content));
            return magic;
        }

        public async Task<dynamic> POST(string requestUri, string parsedContent)
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["baseURL"] + requestUri));
            http.ContentType = "application/json";
            http.Method = "POST";
            //http.Accept = "application/json";
            string token = Variables.Token;
            http.Headers["Authorization"] = "Bearer " + token;

            ASCIIEncoding encoding = new ASCIIEncoding();
            if (parsedContent != "")
            {
                Byte[] bytes = encoding.GetBytes(parsedContent);
                Stream newStream = http.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();
            }

            var response = await http.GetResponseAsync();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = await sr.ReadToEndAsync();
            dynamic magic = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject(content));
            return magic;
        }

        public async Task<dynamic> PUT(string requestUri, string parsedContent)
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["baseURL"] + requestUri));
            http.Method = "PUT";
            http.ContentType = "application/json";
            http.Accept = "application/json";
            string token = Variables.Token;
            http.Headers["Authorization"] = "Bearer " + token;
            ASCIIEncoding encoding = new ASCIIEncoding();
            if (parsedContent != "")
            {
                Byte[] bytes = encoding.GetBytes(parsedContent);
                Stream newStream = http.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();
            }
            var response = await http.GetResponseAsync();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = await sr.ReadToEndAsync();
            dynamic magic = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject(content));
            return magic;
        }

        public async Task<dynamic> DELETE(string requestUri)
        {
            if (requestUri == null)
            {
                throw new ArgumentNullException("RequestUri");
            }

            var http = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["baseURL"] + requestUri));
            http.Method = "DELETE";
            http.ContentType = "application/x-www-form-urlencoded";
            http.Accept = "application/json";
            http.Headers["Authorization"] = "Bearer " + Variables.Token;

            var response = await http.GetResponseAsync();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = await sr.ReadToEndAsync();
            dynamic magic = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject(content));
            return magic;
        }

        public async Task<dynamic> POST(string requestUri, System.Net.Http.MultipartFormDataContent formData)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseURL"]);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Variables.Token);
                var response = await client.PostAsync(requestUri, formData);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic magic = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject(content));
                    return magic;
                }
            }
            return null;
        }

        public async Task<dynamic> PUT(string requestUri, string parsedContent, System.Net.Http.MultipartFormDataContent formData)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Variables.Token);
                var response = await client.PutAsync(requestUri, formData);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic magic = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject(content));
                    return magic;
                }
            }
            return null;
        }
    }
}
