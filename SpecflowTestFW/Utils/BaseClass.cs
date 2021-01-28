using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowTestFW.Utils
{
    public class BaseClass
    {
        public BaseClass(IWebDriver Driver)
        {
            this.Driver = Driver;
        }
        public IWebDriver Driver { get; set; }
    }
}
