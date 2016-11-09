﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;
using System.Windows;
namespace Communitel.helpers
{
    class ServiceRequest
    {
        
        public ServiceRequest()
        {
            
        }
        public dynamic requestToken(string oauthUri, string parsedContent)
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["baseURL"] + oauthUri));
            http.ContentType = "application/x-www-form-urlencoded";
            http.Method = "POST";
            
            ASCIIEncoding encoding = new ASCIIEncoding();
            if(parsedContent != "") {
                Byte[] bytes = encoding.GetBytes(parsedContent);
                Stream newStream = http.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();
            }
            
            var response = http.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();
            dynamic magic = JsonConvert.DeserializeObject(content);
            return magic;
        }

        public dynamic GET(string requestUri, string token)
        {
            if (requestUri == null)
            {
                throw new ArgumentNullException("RequestUri");
            }

            var http = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["baseURL"]+requestUri));
            http.Method = "GET";
            http.ContentType = "application/x-www-form-urlencoded";
            http.Accept = "application/json";
            http.Headers["Authorization"] = "Bearer " + token;
            
            var response = http.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();
            dynamic magic = JsonConvert.DeserializeObject(content);
            return magic;
        }
        public dynamic PUT(string requestUri, string token, string parsedContent)
        {
            if (requestUri == null)
            {
                throw new ArgumentNullException("RequestUri");
            }

            var http = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["baseURL"] + requestUri));
            http.Method = "PUT";
            http.ContentType = "application/x-www-form-urlencoded";
            
            http.Accept = "application/json";
            http.Headers["Authorization"] = "Bearer " + token;
            ASCIIEncoding encoding = new ASCIIEncoding();
            if (parsedContent != "")
            {
                Byte[] bytes = encoding.GetBytes(parsedContent);
                http.ContentLength = bytes.Length;
                Stream newStream = http.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();
            }
            var response = http.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();
            dynamic magic = JsonConvert.DeserializeObject(content);
            MessageBox.Show("Information updated!");
            return magic;
        }

    }
}
