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
using WebSiteGUITests.RideShare;
using System.Threading;


namespace WebSiteGUITests
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class RideShareWebSiteTests
    {
        protected RideShareWebAdapter adapter;
        protected RideShareWebAssertion assert;
        protected RideShareDataSet data;

        public RideShareWebSiteTests()
        {
            this.adapter = new RideShareWebAdapter(this.UIMap);
            this.assert = new RideShareWebAssertion(this.UIMap);
            this.data = new RideShareDataSet();
        }

        [TestMethod]
        public void CodedUITestMethod1()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            adapter.Login(data.CorrectEmail, data.CorrectPassword);
            adapter.GoToPublishRide();

            adapter.addStop("haifa");
            adapter.addStop("telaviv");
            adapter.addStop("beersheva");

        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            adapter.StartRideShare();
            try
            {
                adapter.Logout();
            }
            catch { }
        }

        ////Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            try
            {
                adapter.ClosePopup();
            }
            catch { }
            try
            {
                adapter.Logout();
            }
            catch { }

            adapter.CloseBrowser();
        }

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        protected TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        protected UIMap map;
    }
}
