using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class Template
    {
        public static string GetTemplate(string filename)
        {
            string template;
            using (StreamReader sr = new StreamReader(filename))
            {
                template = sr.ReadToEnd();
            }
            return template;
        }
    }
}