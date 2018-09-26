using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Web;

namespace WebApp
{
    public class FormParametersHandler : IHttpHandler
    {
        const string pathToFileWithForms = "E:/WebTask/Web/WebApp/b.html";
        const string pathToFileWithResult = "E:/WebTask/Web/WebApp/a.html";

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var req = context.Request;
            var resp = context.Response;

            string templateWithForms = Template.GetTemplate(pathToFileWithForms);
            resp.Write(templateWithForms);

            NameValueCollection parameters = req.QueryString;
            int count = parameters.AllKeys.Length;

            string templateWithResult = Template.GetTemplate(pathToFileWithResult);
            if (count == 0)
            {
                resp.Write("no parameters");
                return;
            }

            if (count < 3)
            {
                resp.Write("not enough parametrs");
                return;
            }

            double a = Convert.ToInt32(parameters[parameters.AllKeys[0]]);
            double b = Convert.ToInt32(parameters[parameters.AllKeys[1]]);
            double c = Convert.ToInt32(parameters[parameters.AllKeys[2]]);

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
                sb.AppendFormat(templateWithResult, a, b, c, solution);
                resp.Write(sb);
            }
            catch (DivideByZeroException)
            {
                resp.Write("The number can't be divided by zero");
            }
        }

    }
}
