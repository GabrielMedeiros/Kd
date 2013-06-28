using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;

namespace Vtex.Kd.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            var loginRequest =
                WebRequest.Create("https://10.1.12.88:8443/login?login=login&username=admin&password=admin");
            loginRequest.Method = "GET";
            loginRequest.AuthenticationLevel = AuthenticationLevel.None;
            var loginResponse = (HttpWebResponse)loginRequest.GetResponse();

            var cookieContainer = new CookieContainer();
            var list = (IEnumerable<Cookie>)loginResponse.Cookies.GetEnumerator();
            list.ToList().ForEach(cookieContainer.Add);

            var getStaRequest =
                (HttpWebRequest)WebRequest.Create("https://10.1.12.88:8443/api/stat/sta");
            getStaRequest.Method = "GET";
            getStaRequest.ContentType = "application/json; charset=utf-8";
            getStaRequest.CookieContainer = cookieContainer;

            var response = getStaRequest.GetResponse();

            string text = "";

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
            }

            System.Console.Write(text);

            System.Console.ReadKey();

        }

        public static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
