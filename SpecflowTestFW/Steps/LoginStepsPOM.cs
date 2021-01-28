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
    public class LoginStepsPOM:CommonMethods
    {

        private Global global;


        public LoginStepsPOM(Global global):base(global)
        {
            this.global = global;
        }

        [FindsBy(How = How.Id, Using = "name")]
        public IWebElement txt_username;

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement txt_password;

        [FindsBy(How = How.XPath, Using = "//button[@id='login']")]
        public IWebElement loginBtn;


        public void LoginURL(string URL)
        {
            Driver.Navigate().GoToUrl(URL);
        }


        public void EnterCredentials(String UserName, String Password)
        {
            EnterText(txt_username ,UserName);
            Thread.Sleep(2000);
            EnterText(txt_password, Password);
        }


        public void ClickLogin()
        {
            Thread.Sleep(2000);
            Click(loginBtn);
        }


    }
}
