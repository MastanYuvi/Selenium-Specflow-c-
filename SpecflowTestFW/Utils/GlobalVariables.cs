using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SpecflowTestFW.Utils
{
    public class GlobalVariables
    {

        public static readonly string URL = TestContext.Parameters["URL"].ToString();
        public static readonly string app_url = ConfigurationManager.AppSettings["app-url"].ToString();

    }
}
