using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Web;

namespace WebApp
{
    public class Handler2 : IHttpHandler
    {
        double a, b, c;
        string text;
        NameValueCollection result;

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var req = context.Request;
            var resp = context.Response;


            ReadFile($"E:/WebTask/Web/WebApp/b.html");
            resp.Write(text);

            result = req.QueryString;
            int count = result.AllKeys.Length;

            ReadFile($"E:/WebTask/Web/WebApp/a.html");
            if (count == 0)
            {
                resp.Write("no parametrs");
            }
            else if (count >= 3)
            {
                a = Convert.ToInt32(result[result.AllKeys[0]]);
                b = Convert.ToInt32(result[result.AllKeys[1]]);
                c = Convert.ToInt32(result[result.AllKeys[2]]);

                StringBuilder sb = new StringBuilder();
                Calculator calc = new Calculator();
                calc.Count(a, b, c);
                if (calc.discr < 0)
                {
                    string xx1 = string.Format("{0}+{1}i", Math.Round(calc.x1, 2).ToString(), Math.Round(calc.x2, 2).ToString());
                    string xx2 = string.Format("{0}-{1}i", Math.Round(calc.x1, 2).ToString(), Math.Round(calc.x2, 2).ToString());
                    sb.AppendFormat(text, a.ToString(), b.ToString(), c.ToString(), xx1, xx2);
                }
                else if (calc.discr == 0)
                {
                    sb.AppendFormat(text, a.ToString(), b.ToString(), c.ToString(), Math.Round(calc.x1, 2).ToString(), "doesn't exist");
                }
                else
                {
                    sb.AppendFormat(text, a.ToString(), b.ToString(), c.ToString(), Math.Round(calc.x1, 2).ToString(), Math.Round(calc.x2, 2).ToString());
                }
                resp.Write(sb);
            }
            else
            {
                resp.Write("not enough parametrs");
            }

        }

        public void ReadFile(string filename)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                text = sr.ReadToEnd();
            }
        }
    }
}
