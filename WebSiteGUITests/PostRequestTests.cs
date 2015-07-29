using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using WebSiteGUITests.RideShare.Data;


namespace WebSiteGUITests
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class PostRequestTests : RideShareWebSiteTests
    {
        private PostRequest request;

        public PostRequestTests()
        {
            this.request = new PostRequest();
        }

        [TestMethod]
        public void PostRequestEmptyFields()
        {
            request.setSmoking(Smoking.yes);
            request.setBags(Bags.big_bag);

            adapter.Login(this.data.CorrectEmail, this.data.CorrectPassword);
            adapter.GoToPostRequest();
            adapter.PostRequest(request);

            assert.MessageAssertion(this.data.BadSource);
        }

        [TestMethod]
        public void PostRequestEmptyFields_AllBut_Source()
        {
            request.setSmoking(Smoking.yes);
            request.setBags(Bags.big_bag);
            request.source = "beersheva";

            adapter.Login(this.data.CorrectEmail, this.data.CorrectPassword);
            adapter.GoToPostRequest();
            adapter.PostRequest(request);

            assert.MessageAssertion(this.data.BadDestination);
        }

        [TestMethod]
        public void PostRequestEmptyFields_AllBut_Source_Destination()
        {
            request.setSmoking(Smoking.yes);
            request.setBags(Bags.big_bag);
            request.source = "beersheva";
            request.destination = "haifa";

            adapter.Login(this.data.CorrectEmail, this.data.CorrectPassword);
            adapter.GoToPostRequest();
            adapter.PostRequest(request);

            assert.MessageAssertion(this.data.BadDate);
        }

        [TestMethod]
        public void PostRequestEmptyFields_AllBut_Source_Destination_Date()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            request.setSmoking(Smoking.yes);
            request.setBags(Bags.big_bag);
            request.source = "beersheva";
            request.destination = "haifa";
            request.setDate(day, month, year);

            adapter.Login(this.data.CorrectEmail, this.data.CorrectPassword);
            adapter.GoToPostRequest();
            adapter.PostRequest(request);

            assert.MessageAssertion(this.data.BadTimeInterval);
        }

        [TestMethod]
        public void PostRequestEmptyFields_AllBut_Source_Destination_Date_TimeFrom()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            request.setSmoking(Smoking.yes);
            request.setBags(Bags.big_bag);
            request.source = "beersheva";
            request.destination = "haifa";
            request.setDate(day, month, year);
            request.fromTime = "14:00";

            adapter.Login(this.data.CorrectEmail, this.data.CorrectPassword);
            adapter.GoToPostRequest();
            adapter.PostRequest(request);

            assert.MessageAssertion(this.data.BadTimeInterval);
        }

        [TestMethod]
        public void PostRequestBadDate()
        {
            DateTime now = DateTime.Now.AddDays(-1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            request.setSmoking(Smoking.yes);
            request.setBags(Bags.big_bag);
            request.source = "beersheva";
            request.destination = "haifa";
            request.setDate(day, month, year);
            request.fromTime = "14:00";
            request.toTime = "15:00";

            adapter.Login(this.data.CorrectEmail, this.data.CorrectPassword);
            adapter.GoToPostRequest();
            adapter.PostRequest(request);

            assert.MessageAssertion(this.data.BadDate);
        }

        [TestMethod]
        public void PostRequestBadTimeInterval()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            request.setSmoking(Smoking.yes);
            request.setBags(Bags.big_bag);
            request.source = "beersheva";
            request.destination = "haifa";
            request.setDate(day, month, year);
            request.fromTime = "14:00";
            request.toTime = "11:00";

            adapter.Login(this.data.CorrectEmail, this.data.CorrectPassword);
            adapter.GoToPostRequest();
            adapter.PostRequest(request);

            assert.MessageAssertion(this.data.BadTimeInterval);
        }

        [TestMethod]
        public void PostRequestCorrect()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            request.setSmoking(Smoking.yes);
            request.setBags(Bags.big_bag);
            request.source = "beersheva";
            request.destination = "haifa";
            request.setDate(day, month, year);
            request.fromTime = "14:00";
            request.toTime = "15:00";

            adapter.Login(this.data.CorrectEmail, this.data.CorrectPassword);
            adapter.GoToPostRequest();
            adapter.PostRequest(request);

            assert.AssertMyRidesPage();
        }
        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion
    }
}
