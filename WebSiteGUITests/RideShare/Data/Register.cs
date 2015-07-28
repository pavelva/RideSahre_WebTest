using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteGUITests.RideShare.Data
{
    public class Register
    {
        public string firstName;
        public string lastName;
        public string email;
        public string phone;
        public string password;
        public string verifiedPassword;

        public Register()
        {
            this.clear();
        }

        public void clear()
        {
            this.firstName = "";
            this.lastName = "";
            this.email = "";
            this.phone = "";
            this.password = "";
            this.verifiedPassword = "";
        }
    }
}
