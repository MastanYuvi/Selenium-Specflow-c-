using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowTestFW.Utils
{
    public class CommonMethods:BaseClass
    {

        private Global global;
        public CommonMethods(Global global):base(global.Driver)
        {
            this.global = global;
            PageFactory.InitElements(Driver, this);
        }




        public void EnterText(IWebElement elementName, String value)
        {
            elementName.SendKeys(value);
        }


        public void Click(IWebElement elementName)
        {
            elementName.Click();
        }


    }
}
