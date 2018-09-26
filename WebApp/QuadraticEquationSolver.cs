using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class QuadraticEquationSolver
    {
        public enum SolutionType
        {
            TwoRoots,
            OneRoot,
            ComplexRoots
        }

        public static (Complex x1,Complex x2, SolutionType type) FindEquationRoots(double a, double b, double c)
        {
            if (a == 0) throw new DivideByZeroException();
            double x, y;
            Complex x1, x2;
            double discriminant = (b * b) - (4 * a * c);
            SolutionType solutiontype;
            if (discriminant < 0)
            {
                x = ((-b) / (2 * a));
                y = (Math.Sqrt(Math.Abs(discriminant))) / (2 * a);
                x1 = new Complex(x, y);
                x2 = new Complex(x, -y);
                solutiontype = SolutionType.ComplexRoots;
            }
            else if (discriminant == 0)
            {
                x = (-b) / (2 * a);
                y = 0;
                x1 = new Complex(x, 0);
                x2 = new Complex(y, 0);
                solutiontype = SolutionType.OneRoot;
            }
            else
            {
                x = ((-b) + (Math.Sqrt(discriminant))) / (2 * a);
                y = ((-b) - (Math.Sqrt(discriminant))) / (2 * a);
                x1 = new Complex(x, 0);
                x2 = new Complex(y, 0);
                solutiontype = SolutionType.TwoRoots;
            }
            return (x1, x2, solutiontype);
        }
    }
}