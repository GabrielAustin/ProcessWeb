using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace Process.Factories
{
    public class HttpFactory
    {
        public HttpFactory()
        {

        }

        public Boolean CheckSchemeBasic(System.Net.Http.Headers.AuthenticationHeaderValue authHeader)
        {
            return authHeader.Scheme.ToLowerInvariant() == "basic";
        }

        public string[] GetCredentials(System.Net.Http.Headers.AuthenticationHeaderValue authHeader)
        {
            //Base 64 encoded string
            var rawCred = authHeader.Parameter;
            var encoding = Encoding.GetEncoding("iso-8859-1");
            var cred = encoding.GetString(Convert.FromBase64String(rawCred));

            var credArray = cred.Split(':');

            return credArray;
        }

        public string Base64Encoding(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
            
        }

        public HttpResponseMessage SetTicket(HttpResponseMessage response, string ticket)
        {
            response.Headers.Add("Authorization", ticket);
            return response;
        }
    }
}