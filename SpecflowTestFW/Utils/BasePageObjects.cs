using SpecflowTestFW.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowTestFW.Utils
{
    public class BasePageObjects
    {

        private Global global;
        public LoginStepsPOM loginPage;
        public LogoutStepsPOM logoutPage;

        public BasePageObjects(Global global)
        {
            this.global = global;
            loginPage = new LoginStepsPOM(global);
            logoutPage = new LogoutStepsPOM(global);
        }

    }
}
