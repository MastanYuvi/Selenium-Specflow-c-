using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SpecflowTestFW.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpecflowTestFW.Steps
{
    public class LogoutStepsPOM:CommonMethods
    {

        private Global global;

        public LogoutStepsPOM(Global global):base(global)
        {
            this.global = global;
        }


        [FindsBy(How = How.Id, Using = "logout")]
        public IWebElement LogoutBtn;


        public void ValidateLogout()
        {
            Thread.Sleep(2000);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            Boolean visible = LogoutBtn.Displayed;
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            if (!visible)
            {
                Assert.Fail("Logout Button is not Displayed");
            }

        }


    }
}
