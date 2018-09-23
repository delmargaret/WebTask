using System;
using System.Collections.Specialized;
using System.IO;
using System.Web;

namespace WebApp
{
    public class Handler : IHttpHandler
    {
        public double x1, x2, discr, a, b, c;
        string paramss;
        string res;

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

            int count = result.AllKeys.Length;
            if (count == 3)
            {
                Count(Convert.ToInt32(result[result.AllKeys[0]]), Convert.ToInt32(result[result.AllKeys[1]]), Convert.ToInt32(result[result.AllKeys[2]]));
                resp.Write("<p>" + paramss + "</p>");
                resp.Write("<p>" + res + "</p>");

            }

            else
            {
                foreach (var key in result.AllKeys)
                {
                    resp.Write("<p>" + "key: " + key + " value: " + result[key] + "</p>");
                }
            }

        }

        public void Count(double a, double b, double c)
        {
            paramss = "a = " + a.ToString() + " b = " + b.ToString() + " c = " + c.ToString();
            discr = (b * b) - (4 * a * c);
            if (discr < 0)
            {
                x1 = ((-b) / (2 * a));
                x2 = (Math.Sqrt(Math.Abs(discr))) / (2 * a);
                res = "x1 = " + Math.Round(x1,2) + " + " + Math.Round(x2, 2) + "i" + " x2 = " + Math.Round(x1, 2) + " - " + Math.Round(x2, 2) + "i";
            }
            else if (discr == 0)
            {
                x1 = (-b) / (2 * a);
                x2 = 0;
                res = "x1 = " + Math.Round(x1, 2);
            }
            else
            {
                x1 = ((-b) + (Math.Sqrt(discr))) / (2 * a);
                x2 = ((-b) - (Math.Sqrt(discr))) / (2 * a);
                res = "x1 = " + Math.Round(x1, 2) + " x2 = " + Math.Round(x2, 2);
            }

        }
    }
}
