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
        public string RegisterBadNameMessage;
        public string RegisterBadEmailMessage;
        public string RegisterBadPhoneMessage;
        public string RegisterBadPasswordMessage;
        public string RegisterPasswordAndVerifiedPasswordDontMatch;
        public string BadSource;
        public string BadDestination;
        public string BadTimeInterval;
        public string BadPassengersAmount;
        public string BadDate;
        public string BadPrice;
        public string deleteRequest;
        public string deleteRide;

        #endregion

        public RideShareDataSet()
        {
            initInput();
            initMessages();
        }

        private void initMessages()
        {
            this.BadLoginMessage = "Wrong email or password!";
            this.RegisterBadNameMessage = "Please Enter Legal Name";
            this.RegisterBadEmailMessage = "Please Enter Legal Email";
            this.RegisterBadPhoneMessage = "Please Enter Legal Phone";
            this.RegisterBadPasswordMessage = "Please Enter Legal Password";
            this.RegisterPasswordAndVerifiedPasswordDontMatch = "Password and verified password not match";

            this.BadSource = "Please Enter Source";
            this.BadDestination = "Please Enter Destination";
            this.BadPrice = "Please Enter Legal Price";
            this.BadPassengersAmount = "Please Enter Legal Passengers Amount";
            this.BadDate = "Please Enter Legal Date";
            this.BadTimeInterval = "Please Enter Legal Exit Time Interval";

            this.deleteRequest = "Are You Sure You Want To Delete The Request?";
            this.deleteRide = "Are You Sure You Want To Delete The Ride?";
        }

        private void initInput()
        {
            this.WrongEmail = "error@error.com";
            this.WrongPassword = "1234567890";

            this.CorrectEmail = "p1@post.bgu.ac.il";
            this.CorrectPassword = "q1";

            string now = DateTime.Now.ToShortDateString();
            this.TestName = "WebTestUser";
            this.TestLastName = "Jonson";
            this.TestPhone = "04-8766666";
            this.TestEmail = "web.test.user" + now.Replace('/','.') + "@post.bgu.ac.il";
            this.TestPassword = "q1w2e3r4";

            this.RegisterData = new Register();
        }
    }
}
