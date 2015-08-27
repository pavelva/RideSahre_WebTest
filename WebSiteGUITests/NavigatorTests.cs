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

        #region basic navigation
        [TestMethod]
        public void SearchRideLinkTest()
        {
            adapter.GoToSearchRide();
            assert.AssertSearchRidePage();

        }

        [TestMethod]
        public void PublishRideLinkTest()
        {
            adapter.GoToPublishRide();
            assert.AssertPublishRidePage();

        }

        [TestMethod]
        public void PostRequestLinkTest()
        {
            adapter.GoToPostRequest();
            assert.AssertPostRequestPage();

        }

        [TestMethod]
        public void MyRidesLinkTest()
        {
            adapter.GoToMyRides();
            assert.AssertMyRidesPage();

        }

        [TestMethod]
        public void HomeLinkTest()
        {
            adapter.GoToMyRides();
            adapter.GoToHome();
            assert.AssertHomePage();

        }

        #endregion

        #region complicated navigation
        [TestMethod]
        public void NavigationTest()
        {
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

        #endregion

        protected override void TestInitialize()
        {
            adapter.Login(data.CorrectEmail, data.CorrectPassword);
        }
    }
}
