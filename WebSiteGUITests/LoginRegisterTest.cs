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
using WebSiteGUITests.RideShare.Data;


namespace WebSiteGUITests
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class LoginRegisterTest : RideShareWebSiteTests
    {
        public LoginRegisterTest() : base()
        {
            
        }

        [TestMethod]
        public void TestBadLogin()
        {

            adapter.Login(data.WrongEmail, data.WrongPassword);
            assert.MessageAssertion(this.data.BadLoginMessage);
            adapter.ClosePopup();
        }


        [TestMethod]
        public void TestCorrectLogin()
        {
            adapter.Login(data.CorrectEmail, data.CorrectPassword);

            assert.AssertCorrectLogin(data.CorrectEmail);
        }

        [TestMethod]
        public void TestOpenRegisterPanel()
        {
            adapter.OpenRegisterPanel();
            assert.AssertRegisterPanel();

        }

        [TestMethod]
        public void TestRegisterEmptyFields_All()
        {
            Register reg = data.RegisterData;
            reg.clear();

            adapter.OpenRegisterPanel();
            adapter.Register(data.RegisterData);
            assert.MessageAssertion(data.RegisterMissingEmailMessage);
        }

        [TestMethod]
        public void TestRegisterEmptyFields_AllBut_Email()
        {
            Register reg = data.RegisterData;
            reg.clear();

            adapter.OpenRegisterPanel();

            reg.email = data.TestEmail;
            adapter.Register(data.RegisterData);
            assert.MessageAssertion(data.RegisterMissingPhoneMessage);
        }

        [TestMethod]
        public void TestRegisterEmptyFields_AllBut_Email_Phone()
        {
            Register reg = data.RegisterData;
            reg.clear();

            adapter.OpenRegisterPanel();

            reg.email = data.TestEmail;
            reg.phone = data.TestPhone;

            adapter.Register(data.RegisterData);
            assert.MessageAssertion(data.RegisterMissingPasswordMessage);

        }

        [TestMethod]
        public void TestRegisterEmptyFields_AllBut_Email_Phone_Password()
        {
            Register reg = data.RegisterData;
            reg.clear();

            adapter.OpenRegisterPanel();


            reg.email = data.TestEmail;
            reg.phone = data.TestPhone;
            reg.password = data.TestPassword;
            adapter.Register(data.RegisterData);
            assert.MessageAssertion(data.RegisterPasswordAndVerifiedPasswordDontMatch);
        }

        [TestMethod]
        public void TestRegisterBadVerifiedPassword()
        {
            Register reg = data.RegisterData;
            reg.clear();

            adapter.OpenRegisterPanel();


            reg.email = data.TestEmail;
            reg.phone = data.TestPhone;
            reg.password = data.TestPassword;
            reg.verifiedPassword = reg.password + "11";
            adapter.Register(data.RegisterData);
            assert.MessageAssertion(data.RegisterPasswordAndVerifiedPasswordDontMatch);
        }

        [TestMethod]
        public void TestRegisterNotBGUMail()
        {
            Register reg = data.RegisterData;
            reg.clear();

            adapter.OpenRegisterPanel();


            reg.email = "badMail@gmail.com";

            reg.firstName = data.TestName;
            reg.lastName = data.TestLastName;
            reg.phone = data.TestPhone;
            reg.password = data.TestPassword;
            reg.verifiedPassword = reg.password;
            adapter.Register(data.RegisterData);
            assert.MessageAssertion(data.RegisterNotBGUMail);
        }

        [TestMethod]
        public void TestRegisterCorrect()
        {
            Register reg = data.RegisterData;
            reg.clear();

            adapter.OpenRegisterPanel();
            
            reg.firstName = data.TestName;
            reg.lastName = data.TestLastName;
            reg.email = data.TestEmail;
            reg.phone = data.TestPhone;
            reg.password = data.TestPassword;
            reg.verifiedPassword = data.TestPassword;

            adapter.Register(data.RegisterData);
            assert.AssertHomePage();
            assert.AssertCorrectLogin(reg.email);

        }
        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            
        //}

        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{

            
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

        //public UIMap UIMap
        //{
        //    get
        //    {
        //        if ((this.map == null))
        //        {
        //            this.map = new UIMap();
        //        }

        //        return this.map;
        //    }
        //}

        //private UIMap map;

        protected override void TestInitialize()
        {
            return;
        }
    }
}
