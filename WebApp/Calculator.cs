using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class Calculator
    {
        public double x1, x2, discr, a, b, c;

        public void Count(double a, double b, double c)
        {
            discr = (b * b) - (4 * a * c);
            if (discr < 0)
            {
                x1 = ((-b) / (2 * a));
                x2 = (Math.Sqrt(Math.Abs(discr))) / (2 * a);
            }
            else if (discr == 0)
            {
                x1 = (-b) / (2 * a);
                x2 = 0;
            }
            else
            {
                x1 = ((-b) + (Math.Sqrt(discr))) / (2 * a);
                x2 = ((-b) - (Math.Sqrt(discr))) / (2 * a);
            }

        }
    }
}