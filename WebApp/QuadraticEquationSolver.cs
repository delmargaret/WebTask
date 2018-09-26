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

        public static (double x1,double x2, SolutionType type) FindEquationRoots(double a, double b, double c)
        {
            if (a == 0) throw new DivideByZeroException();
            double x1, x2;
            double discriminant = (b * b) - (4 * a * c);
            SolutionType solutiontype;
            if (discriminant < 0)
            {
                x1 = ((-b) / (2 * a));
                x2 = (Math.Sqrt(Math.Abs(discriminant))) / (2 * a);
                solutiontype = SolutionType.ComplexRoots;
            }
            else if (discriminant == 0)
            {
                x1 = (-b) / (2 * a);
                x2 = 0;
                solutiontype = SolutionType.OneRoot;
            }
            else
            {
                x1 = ((-b) + (Math.Sqrt(discriminant))) / (2 * a);
                x2 = ((-b) - (Math.Sqrt(discriminant))) / (2 * a);
                solutiontype = SolutionType.TwoRoots;
            }
            return (x1, x2, solutiontype);
        }
    }
}