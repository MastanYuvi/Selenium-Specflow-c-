using SpecflowTestFW.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecflowTestFW.StepDefinitions
{
    [Binding]
    public sealed class LoginStepDefinitions:BasePageObjects
    {

        private Global global;

        public LoginStepDefinitions(Global global):base(global)
        {
            this.global = global;
        }


        [Given(@"I Enter URL")]
        public void GivenIEnterURL()
        {
            loginPage.LoginURL(GlobalVariables.app_url);
        }


        [Given(@"I Enter (.*) and (.*)")]
        public void GivenIEnterAnd(string userName, string Password)
        {
            loginPage.EnterCredentials(userName, Password);
        }


        [Then(@"I Click Login Button")]
        public void ThenIClickLoginButton()
        {
            loginPage.ClickLogin();
        }

        [Then(@"I Validate Logout Button")]
        public void ThenIValidateLogoutButton()
        {
            //ScenarioContext.Current.Pending();
            logoutPage.ValidateLogout();
        }



    }
}
