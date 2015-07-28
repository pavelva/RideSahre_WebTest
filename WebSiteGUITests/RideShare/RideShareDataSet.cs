using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteGUITests.RideShare.Data;

namespace WebSiteGUITests.RideShare
{
    public class RideShareDataSet
    {
        #region input

        public string WrongEmail;
        public string WrongPassword;

        public string CorrectEmail;
        public string CorrectPassword;

        public string TestEmail;
        public string TestPassword;
        public string TestName;
        public string TestLastName;
        public string TestPhone;

        public Register RegisterData;
        #endregion

        #region messages

        public string BadLoginMessage;
        public string RegisterMissingEmailMessage;
        public string RegisterMissingPhoneMessage;
        public string RegisterMissingPasswordMessage;
        public string RegisterPasswordAndVerifiedPasswordDontMatch;
        public string RegisterNotBGUMail;

        #endregion

        public RideShareDataSet()
        {
            initInput();
            initMessages();
        }

        private void initMessages()
        {
            this.BadLoginMessage = "Wrong email or password!";
            this.RegisterMissingEmailMessage = "Missing Fields - Key: email";
            this.RegisterMissingPhoneMessage = "Missing Fields - Key: phone";
            this.RegisterMissingPasswordMessage = "Missing Fields - Key: password";
            this.RegisterPasswordAndVerifiedPasswordDontMatch = "Password and verified password not match";
            this.RegisterNotBGUMail = "Registration Must be Done with BGU Mail";
        }

        private void initInput()
        {
            this.WrongEmail = "error@error.com";
            this.WrongPassword = "1234567890";

            this.CorrectEmail = "p1@post.bgu.ac.il";
            this.CorrectPassword = "q1";

            string now = DateTime.Now.ToShortDateString();
            this.TestName = "User_" + now;
            this.TestLastName = "Jonson";
            this.TestPhone = "04-8766666";
            this.TestEmail = "user_" + now + "@post.bgu.ac.il";
            this.TestPassword = "q1w2e3r4";

            this.RegisterData = new Register();
        }
    }
}
