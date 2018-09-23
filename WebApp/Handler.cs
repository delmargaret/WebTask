using System;
using System.Collections.Specialized;
using System.IO;
using System.Web;

namespace WebApp
{
    public class Handler : IHttpHandler
    {

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var req = context.Request;
            var resp = context.Response;

            NameValueCollection result;
            result = req.QueryString;

            Calculator calc = new Calculator();

            int count = result.AllKeys.Length;
            if (count == 3)
            {
                calc.Count(Convert.ToInt32(result[result.AllKeys[0]]), Convert.ToInt32(result[result.AllKeys[1]]), Convert.ToInt32(result[result.AllKeys[2]]));
                resp.Write("<p>" + calc.paramss + "</p>");
                resp.Write("<p>" + calc.res + "</p>");

            }

            else
            {
                foreach (var key in result.AllKeys)
                {
                    resp.Write("<p>" + "key: " + key + " value: " + result[key] + "</p>");
                }
            }

        }
    }
}
