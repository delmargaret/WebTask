using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class Calculator
    {
        public double x1, x2, discr, a, b, c;
        public string paramss;
        public string res;

        public void Count(double a, double b, double c)
        {
            paramss = "a = " + a.ToString() + " b = " + b.ToString() + " c = " + c.ToString();
            discr = (b * b) - (4 * a * c);
            if (discr < 0)
            {
                x1 = ((-b) / (2 * a));
                x2 = (Math.Sqrt(Math.Abs(discr))) / (2 * a);
                res = "x1 = " + Math.Round(x1, 2) + " + " + Math.Round(x2, 2) + "i" + " x2 = " + Math.Round(x1, 2) + " - " + Math.Round(x2, 2) + "i";
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