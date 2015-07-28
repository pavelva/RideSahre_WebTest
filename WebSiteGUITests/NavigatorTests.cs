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
using System.Threading;


namespace WebSiteGUITests
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class NavigatorTests : RideShareWebSiteTests
    {
        public NavigatorTests() : base()
        {
        }

        [TestMethod]
        public void SearchRideLinkTest()
        {
            adapter.Login(data.CorrectEmail, data.CorrectPassword);
            adapter.GoToSearchRide();
            assert.AssertSearchRidePage();

        }

        [TestMethod]
        public void PublishRideLinkTest()
        {
            adapter.Login(data.CorrectEmail, data.CorrectPassword);
            adapter.GoToPublishRide();
            assert.AssertPublishRidePage();

        }

        [TestMethod]
        public void PostRequestLinkTest()
        {
            adapter.Login(data.CorrectEmail, data.CorrectPassword);
            adapter.GoToPostRequest();
            assert.AssertPostRequestPage();

        }

        [TestMethod]
        public void MyRidesLinkTest()
        {
            adapter.Login(data.CorrectEmail, data.CorrectPassword);
            adapter.GoToMyRides();
            assert.AssertMyRidesPage();

        }

        [TestMethod]
        public void HomeLinkTest()
        {
            adapter.Login(data.CorrectEmail, data.CorrectPassword);
            adapter.GoToMyRides();
            adapter.GoToHome();
            assert.AssertHomePage();

        }

        [TestMethod]
        public void NavigationTest()
        {
            adapter.Login(data.CorrectEmail, data.CorrectPassword);

            adapter.GoToMyRides();
            Thread.Sleep(1500); //allow link color to change
            assert.AssertMyRidesPage();

            adapter.GoToPostRequest();
            Thread.Sleep(1500); //allow link color to change
            assert.AssertPostRequestPage();

            adapter.GoToHome();
            Thread.Sleep(1500); //allow link color to change
            assert.AssertHomePage();

            adapter.GoToPublishRide();
            Thread.Sleep(1500); //allow link color to change
            assert.AssertPublishRidePage();

            adapter.GoToSearchRide();
            Thread.Sleep(1500); //allow link color to change
            assert.AssertSearchRidePage();

            adapter.GoToHome();
            Thread.Sleep(1500); //allow link color to change
            assert.AssertHomePage();

            adapter.GoToPublishRide();
            Thread.Sleep(1500); //allow link color to change
            assert.AssertPublishRidePage();

            adapter.GoToPostRequest();
            Thread.Sleep(1500); //allow link color to change
            assert.AssertPostRequestPage();
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

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        //public TestContext TestContext
        //{
        //    get
        //    {
        //        return testContextInstance;
        //    }
        //    set
        //    {
        //        testContextInstance = value;
        //    }
        //}
        //private TestContext testContextInstance;
    }
}
