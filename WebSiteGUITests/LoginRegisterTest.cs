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

        #region bad register

        #region empty fields

        [TestMethod]
        public void TestRegisterEmptyFields_All()
        {
            Register reg = data.RegisterData;
            reg.clear();

            adapter.OpenRegisterPanel();
            adapter.Register(data.RegisterData);
            assert.MessageAssertion(data.RegisterBadNameMessage);
        }

        [TestMethod]
        public void TestRegisterEmptyFields_AllBut_Email()
        {
            Register reg = data.RegisterData;
            reg.clear();

            adapter.OpenRegisterPanel();

            reg.email = data.TestEmailBGU;
            adapter.Register(data.RegisterData);
            assert.MessageAssertion(data.RegisterBadNameMessage);
        }

        [TestMethod]
        public void TestRegisterEmptyFields_AllBut_Email_Phone()
        {
            Register reg = data.RegisterData;
            reg.clear();

            adapter.OpenRegisterPanel();

            reg.email = data.TestEmailBGU;
            reg.phone = data.TestPhone;

            adapter.Register(data.RegisterData);
            assert.MessageAssertion(data.RegisterBadNameMessage);

        }

        [TestMethod]
        public void TestRegisterEmptyFields_AllBut_Email_Phone_Password()
        {
            Register reg = data.RegisterData;
            reg.clear();

            adapter.OpenRegisterPanel();


            reg.email = data.TestEmailBGU;
            reg.phone = data.TestPhone;
            reg.password = data.TestPassword;
            adapter.Register(data.RegisterData);
            assert.MessageAssertion(data.RegisterPasswordAndVerifiedPasswordDontMatch);
        }

        [TestMethod]
        public void TestRegisterNoFirstName()
        {
            Register reg = data.RegisterData;
            reg.clear();

            adapter.OpenRegisterPanel();

            reg.firstName = "";
            reg.lastName = data.TestLastName;
            reg.email = data.TestEmailBGU;
            reg.phone = data.TestPhone;
            reg.password = data.TestPassword;
            reg.verifiedPassword = data.TestPassword;

            adapter.Register(data.RegisterData);
            assert.MessageAssertion(data.RegisterBadNameMessage);

        }

        [TestMethod]
        public void TestRegisterNoLastName()
        {
            Register reg = data.RegisterData;
            reg.clear();

            adapter.OpenRegisterPanel();

            reg.firstName = data.TestName;
            reg.lastName = "";
            reg.email = data.TestEmailBGU;
            reg.phone = data.TestPhone;
            reg.password = data.TestPassword;
            reg.verifiedPassword = data.TestPassword;

            adapter.Register(data.RegisterData);
            assert.MessageAssertion(data.RegisterBadNameMessage);
        }

        #endregion

        #region invalid data
        [TestMethod]
        public void TestRegisterBadVerifiedPassword()
        {
            Register reg = data.RegisterData;
            reg.clear();

            adapter.OpenRegisterPanel();


            reg.email = data.TestEmailBGU;
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
            assert.MessageAssertion(data.RegisterBadEmailMessage);
        }

        [TestMethod]
        public void TestRegisterNumericName()
        {
            Register reg = data.RegisterData;
            reg.clear();

            adapter.OpenRegisterPanel();

            reg.firstName = data.TestName + '1';
            reg.lastName = data.TestLastName;
            reg.email = data.TestEmailBGU;
            reg.phone = data.TestPhone;
            reg.password = data.TestPassword;
            reg.verifiedPassword = data.TestPassword;

            adapter.Register(data.RegisterData);
            assert.MessageAssertion(data.RegisterBadNameMessage);

        }

        [TestMethod]
        public void TestRegisterBadEmailFormat()
        {
            Register reg = data.RegisterData;
            reg.clear();

            adapter.OpenRegisterPanel();

            reg.firstName = data.TestName;
            reg.lastName = data.TestLastName;
            reg.email = "user.bgu.ac.il";
            reg.phone = data.TestPhone;
            reg.password = data.TestPassword;
            reg.verifiedPassword = data.TestPassword;

            adapter.Register(data.RegisterData);
            assert.MessageAssertion(data.RegisterBadEmailMessage);
        }

        [TestMethod]
        public void TestRegisterBadPhoneFormat()
        {
            Register reg = data.RegisterData;
            reg.clear();

            adapter.OpenRegisterPanel();

            reg.firstName = data.TestName;
            reg.lastName = data.TestLastName;
            reg.email = data.TestEmailBGU;
            reg.phone = "12-43-2346756";
            reg.password = data.TestPassword;
            reg.verifiedPassword = data.TestPassword;

            adapter.Register(data.RegisterData);
            assert.MessageAssertion(data.RegisterBadPhoneMessage);
        }

        [TestMethod]
        public void TestRegisterPhoneWithChar()
        {
            Register reg = data.RegisterData;
            reg.clear();

            adapter.OpenRegisterPanel();

            reg.firstName = data.TestName;
            reg.lastName = data.TestLastName;
            reg.email = data.TestEmailBGU;
            reg.phone = "054-55548a4";
            reg.password = data.TestPassword;
            reg.verifiedPassword = data.TestPassword;

            adapter.Register(data.RegisterData);
            assert.MessageAssertion(data.RegisterBadPhoneMessage);
        }

        #endregion

        #region correct register
        [TestMethod]
        public void TestRegisterCorrectBGUEmail()
        {
            Register reg = data.RegisterData;
            reg.clear();

            adapter.OpenRegisterPanel();
            
            reg.firstName = data.TestName;
            reg.lastName = data.TestLastName;
            reg.email = data.TestEmailBGU;
            reg.phone = data.TestPhone;
            reg.password = data.TestPassword;
            reg.verifiedPassword = data.TestPassword;

            adapter.Register(data.RegisterData);
            assert.AssertHomePage();
            assert.AssertCorrectLogin(reg.email);
        }

        [TestMethod]
        public void TestRegisterCorrectPOSTEmail()
        {
            Register reg = data.RegisterData;
            reg.clear();

            adapter.OpenRegisterPanel();

            reg.firstName = data.TestName;
            reg.lastName = data.TestLastName;
            reg.email = data.TestEmailPost;
            reg.phone = data.TestPhone;
            reg.password = data.TestPassword;
            reg.verifiedPassword = data.TestPassword;

            adapter.Register(data.RegisterData);
            assert.AssertHomePage();
            assert.AssertCorrectLogin(reg.email);
        }

        [TestMethod]
        public void TestRegisterCorrectSEEmail()
        {
            Register reg = data.RegisterData;
            reg.clear();

            adapter.OpenRegisterPanel();

            reg.firstName = data.TestName;
            reg.lastName = data.TestLastName;
            reg.email = data.TestEmailISE;
            reg.phone = data.TestPhone;
            reg.password = data.TestPassword;
            reg.verifiedPassword = data.TestPassword;

            adapter.Register(data.RegisterData);
            assert.AssertHomePage();
            assert.AssertCorrectLogin(reg.email);
        }

        [TestMethod]
        public void TestRegisterCorrectISEEmail()
        {
            Register reg = data.RegisterData;
            reg.clear();

            adapter.OpenRegisterPanel();

            reg.firstName = data.TestName;
            reg.lastName = data.TestLastName;
            reg.email = data.TestEmailISE;
            reg.phone = data.TestPhone;
            reg.password = data.TestPassword;
            reg.verifiedPassword = data.TestPassword;

            adapter.Register(data.RegisterData);
            assert.AssertHomePage();
            assert.AssertCorrectLogin(reg.email);
        }

        [TestMethod]
        public void TestRegisterCorrectCSEmail()
        {
            Register reg = data.RegisterData;
            reg.clear();

            adapter.OpenRegisterPanel();

            reg.firstName = data.TestName;
            reg.lastName = data.TestLastName;
            reg.email = data.TestEmailCS;
            reg.phone = data.TestPhone;
            reg.password = data.TestPassword;
            reg.verifiedPassword = data.TestPassword;

            adapter.Register(data.RegisterData);
            assert.AssertHomePage();
            assert.AssertCorrectLogin(reg.email);
        }

        #endregion

        #endregion

        protected override void TestInitialize()
        {
            return;
        }
    }
}
