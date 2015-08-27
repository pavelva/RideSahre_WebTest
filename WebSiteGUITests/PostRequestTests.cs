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

        #region misssing fields

        [TestMethod]
        public void PostRequestEmptyFields()
        {
            request.smoking = Smoking.yes;
            request.bags = Bags.big_bag;

            adapter.PostRequest(request);

            assert.MessageAssertion(this.data.BadSource);
        }

        [TestMethod]
        public void PostRequestEmptyFields_AllBut_Source()
        {
            request.smoking = Smoking.yes;
            request.bags = Bags.big_bag;
            request.source = "beersheva";

            adapter.PostRequest(request);

            assert.MessageAssertion(this.data.BadDestination);
        }

        [TestMethod]
        public void PostRequestEmptyFields_AllBut_Source_Destination()
        {
            request.smoking = Smoking.yes;
            request.bags = Bags.big_bag;
            request.source = "beersheva";
            request.destination = "haifa";

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

            request.smoking = Smoking.yes;
            request.bags = Bags.big_bag;
            request.source = "beersheva";
            request.destination = "haifa";
            request.setDate(day, month, year);

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

            request.smoking = Smoking.yes;
            request.bags = Bags.big_bag;
            request.source = "beersheva";
            request.destination = "haifa";
            request.setDate(day, month, year);
            request.fromTime = "14:00";

            adapter.PostRequest(request);

            assert.MessageAssertion(this.data.BadTimeInterval);
        }

        #endregion

        #region invalid input

        [TestMethod]
        public void PostRequestBadInputDateWithChar()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            request.smoking = Smoking.yes;
            request.bags = Bags.big_bag;
            request.source = "beersheva";
            request.destination = "haifa";
            request.setDate("a", month.ToString(), year.ToString());
            request.fromTime = "14:00";
            request.toTime = "15:00";

            adapter.PostRequest(request);

            assert.MessageAssertion(this.data.BadDate);
        }

        [TestMethod]
        public void PostRequestBadInputDateWithNegative()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            request.smoking = Smoking.yes;
            request.bags = Bags.big_bag;
            request.source = "beersheva";
            request.destination = "haifa";
            request.setDate("-1", month.ToString(), year.ToString());
            request.fromTime = "14:00";
            request.toTime = "15:00";

            adapter.PostRequest(request);

            assert.MessageAssertion(this.data.BadDate);
        }

        [TestMethod]
        public void PostRequestBadInputTimeWithChar()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            request.smoking = Smoking.yes;
            request.bags = Bags.big_bag;
            request.source = "beersheva";
            request.destination = "haifa";
            request.setDate(day, month, year);
            request.fromTime = "1a:00";
            request.toTime = "15:00";

            adapter.PostRequest(request);

            assert.MessageAssertion(this.data.BadTimeInterval);
        }

        [TestMethod]
        public void PostRequestBadInputTimeWithNegative()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            request.smoking = Smoking.yes;
            request.bags = Bags.big_bag;
            request.source = "beersheva";
            request.destination = "haifa";
            request.setDate(day, month, year);
            request.fromTime = "-14:00";
            request.toTime = "15:00";

            adapter.PostRequest(request);

            assert.MessageAssertion(this.data.BadTimeInterval);
        }

        #endregion

        #region bad data

        [TestMethod]
        public void PostRequestBadDate()
        {
            DateTime now = DateTime.Now.AddDays(-1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            request.smoking = Smoking.yes;
            request.bags = Bags.big_bag;
            request.source = "beersheva";
            request.destination = "haifa";
            request.setDate(day, month, year);
            request.fromTime = "14:00";
            request.toTime = "15:00";

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

            request.smoking = Smoking.yes;
            request.bags = Bags.big_bag;
            request.source = "beersheva";
            request.destination = "haifa";
            request.setDate(day, month, year);
            request.fromTime = "14:00";
            request.toTime = "11:00";

            adapter.PostRequest(request);

            assert.MessageAssertion(this.data.BadTimeInterval);
        }

        [TestMethod]
        public void PostRequestBadInputSourceDoesntExist()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            request.smoking = Smoking.yes;
            request.bags = Bags.big_bag;
            request.source = "1234aaa2";
            request.destination = "haifa";
            request.setDate(day, month, year);
            request.fromTime = "14:00";
            request.toTime = "15:00";

            adapter.PostRequest(request);

            assert.MessageAssertion(this.data.BadAddress);
        }

        [TestMethod]
        public void PostRequestBadInputDestinationDoesntExist()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            request.smoking = Smoking.yes;
            request.bags = Bags.big_bag;
            request.source = "beersheva";
            request.destination = "1234aaa2";
            request.setDate(day, month, year);
            request.fromTime = "14:00";
            request.toTime = "15:00";

            adapter.PostRequest(request);

            assert.MessageAssertion(this.data.BadAddress);
        }

        #endregion

        #region correct input
        [TestMethod]
        public void PostRequestCorrectSmokingBigBag()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            request.smoking = Smoking.yes;
            request.bags = Bags.big_bag;
            request.source = "beersheva";
            request.destination = "haifa";
            request.setDate(day, month, year);
            request.fromTime = "14:00";
            request.toTime = "15:00";

            adapter.PostRequest(request);

            assert.AssertMyRidesPage();
        }

        [TestMethod]
        public void PostRequestCorrectSmokingSmallBag()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            request.smoking = Smoking.yes;
            request.bags = Bags.none;
            request.source = "beersheva";
            request.destination = "haifa";
            request.setDate(day, month, year);
            request.fromTime = "14:00";
            request.toTime = "15:00";

            adapter.PostRequest(request);

            assert.AssertMyRidesPage();
        }

        [TestMethod]
        public void PostRequestCorrectNoneSmokingBigBag()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            request.smoking = Smoking.no;
            request.bags = Bags.big_bag;
            request.source = "beersheva";
            request.destination = "haifa";
            request.setDate(day, month, year);
            request.fromTime = "14:00";
            request.toTime = "15:00";

            adapter.PostRequest(request);

            assert.AssertMyRidesPage();
        }

        [TestMethod]
        public void PostRequestCorrectNonSmokingSmallBag()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            request.smoking = Smoking.no;
            request.bags = Bags.none;
            request.source = "beersheva";
            request.destination = "haifa";
            request.setDate(day, month, year);
            request.fromTime = "14:00";
            request.toTime = "15:00";

            adapter.PostRequest(request);

            assert.AssertMyRidesPage();
        }

        [TestMethod]
        public void PostRequestCorrectDontCareSmokingBigBag()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            request.smoking = Smoking.dontCare;
            request.bags = Bags.big_bag;
            request.source = "beersheva";
            request.destination = "haifa";
            request.setDate(day, month, year);
            request.fromTime = "14:00";
            request.toTime = "15:00";

            adapter.PostRequest(request);

            assert.AssertMyRidesPage();
        }

        [TestMethod]
        public void PostRequestCorrectDontCareSmokingSmallBag()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            request.smoking = Smoking.dontCare;
            request.bags = Bags.none;
            request.source = "beersheva";
            request.destination = "haifa";
            request.setDate(day, month, year);
            request.fromTime = "14:00";
            request.toTime = "15:00";

            adapter.PostRequest(request);

            assert.AssertMyRidesPage();
        }

        #endregion

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

        protected override void TestInitialize()
        {
            adapter.Login(data.CorrectEmail, data.CorrectPassword);
            adapter.GoToPostRequest();
        }
    }
}
