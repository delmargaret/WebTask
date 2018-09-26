using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class Complex
    {
        private double real, imaginary;

        public Complex(double rl, double im)
        {
            this.real = rl;
            this.imaginary = im;
        }

        public override string ToString()
        {
            if (imaginary == 0)
            {
                return Math.Round(real,2).ToString();
            }
            else
            {
                return string.Format("{0} + {1}i", Math.Round(real,2).ToString(), Math.Round(imaginary,2).ToString());
            }
        }
    }
}