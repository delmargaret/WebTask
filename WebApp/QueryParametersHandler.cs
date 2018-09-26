using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Web;

namespace WebApp
{
    public class QueryParametersHandler : IHttpHandler
    {
        const string path = "E:/WebTask/Web/WebApp/a.html";

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var req = context.Request;
            var resp = context.Response;

            var template = Template.GetTemplate(path);
            string query = req.Url.Query.ToString();

            if (query.Length == 0)
            {
                resp.Write("no parametrs");
                return;
            }

            string[] parameters = query.Split('/');
            if (parameters.Length < 4)
            {
                resp.Write("not enough parameters");
                return;
            }

            double a = Convert.ToInt32(parameters[1]);
            double b = Convert.ToInt32(parameters[2]);
            double c = Convert.ToInt32(parameters[3]);

            try
            {
                var result = QuadraticEquationSolver.FindEquationRoots(a, b, c);
                string solution = "";
                switch (result.type)
                {
                    case QuadraticEquationSolver.SolutionType.ComplexRoots:
                        solution = string.Format("x<sub>1</sub> = {0}+{1}i, x<sub>2</sub> = {0}-{1}i", Math.Round(result.x1, 2), Math.Round(result.x2, 2));
                        break;
                    case QuadraticEquationSolver.SolutionType.OneRoot:
                        solution = string.Format("x<sub>1</sub> = {0}", Math.Round(result.x1, 2));
                        break;
                    case QuadraticEquationSolver.SolutionType.TwoRoots:
                        solution = string.Format("x<sub>1</sub> = {0}, x<sub>2</sub> = {1}", Math.Round(result.x1, 2), Math.Round(result.x2, 2));
                        break;
                    default:
                        solution = "no solution";
                        break;

                }
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat(template, a, b, c, solution);
                resp.Write(sb);
            }
            catch (DivideByZeroException)
            {
                resp.Write("The number can't be divided by zero");
            }
        }

    }
}
