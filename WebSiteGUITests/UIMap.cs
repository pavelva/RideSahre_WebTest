namespace WebSiteGUITests
{
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using System;
    using System.Collections.Generic;
    using System.CodeDom.Compiler;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    using System.Drawing;
    using System.Windows.Input;
    using System.Text.RegularExpressions;
    using WebSiteGUITests.RideShare.Data;
    using System.Threading;


    public partial class UIMap
    {

        /// <summary>
        /// PostRequest - Use 'PostRequestParams' to pass parameters into this method.
        /// </summary>
        public void PostRequest(Smoking smoking, Bags bags)
        {
            #region Variable Declarations
            HtmlEdit uIPostInputEdit = this.UIRideShareWindowsInteWindow.UIRideShareDocument.UIPostInputEdit;
            HtmlSpan uIBeershebaPane1 = this.UIRideShareWindowsInteWindow.UIRideShareDocument.UIBeershebaPane1;
            HtmlEdit uIPostInputEdit1 = this.UIRideShareWindowsInteWindow.UIRideShareDocument.UIPostInputEdit1;
            HtmlSpan uIIsraelPane1 = this.UIRideShareWindowsInteWindow.UIRideShareDocument.UIIsraelPane1;
            HtmlRadioButton uINORadioButton1 = this.UIRideShareWindowsInteWindow.UIRideShareDocument.UINORadioButton1;
            HtmlRadioButton uIYesRadioButton1 = this.UIRideShareWindowsInteWindow.UIRideShareDocument.UIYesRadioButton1;
            HtmlRadioButton uIDontcareRadioButton1 = this.UIRideShareWindowsInteWindow.UIRideShareDocument.UIDontcareRadioButton1;
            HtmlRadioButton uIBigbagRadioButton1 = this.UIRideShareWindowsInteWindow.UIRideShareDocument.UIBigbagRadioButton1;
            HtmlRadioButton uINoneSmallbagRadioButton1 = this.UIRideShareWindowsInteWindow.UIRideShareDocument.UINoneSmallbagRadioButton1;
            HtmlEdit uIDateEdit1 = this.UIRideShareWindowsInteWindow.UIRideShareDocument.UIDateEdit1;
            HtmlEdit uIPostFromTimeInputEdit1 = this.UIRideShareWindowsInteWindow.UIRideShareDocument.UIPostFromTimeInputEdit1;
            HtmlEdit uIPostToTimeInputEdit1 = this.UIRideShareWindowsInteWindow.UIRideShareDocument.UIPostToTimeInputEdit1;
            HtmlInputButton uIPostButton = this.UIRideShareWindowsInteWindow.UIRideShareDocument.UIPostContentPane2.UIPostButton;
            #endregion

            // Type 'beersheba' in 'postInput' text box
            uIPostInputEdit.Text = this.PostRequestParams.UIPostInputEditText;
            Thread.Sleep(2000);
            Keyboard.SendKeys("{Down}");
            Keyboard.SendKeys("{Enter}");
            //try
            //{
            //    // Click 'Beersheba' pane
            //    Mouse.Click(uIBeershebaPane1, new Point(641, 348));
            //}
            //catch { }

            // Type 'haifa' in 'postInput' text box
            uIPostInputEdit1.Text = this.PostRequestParams.UIPostInputEdit1Text;
            Thread.Sleep(2000);
            Keyboard.SendKeys("{Down}");
            Keyboard.SendKeys("{Enter}");
            //try
            //{
            //    // Click 'Israel' pane
            //    Mouse.Click(uIIsraelPane1, new Point(20, 4));
            //}
            //catch { }

            // Select 'No' radio button
            if (smoking == Smoking.no)
                uINORadioButton1.Selected = this.PostRequestParams.UINORadioButton1Selected;

            // Select 'Yes' radio button
            if (smoking == Smoking.yes)
                uIYesRadioButton1.Selected = this.PostRequestParams.UIYesRadioButton1Selected;

            // Select 'Dont care' radio button
            if (smoking == Smoking.dontCare)
                uIDontcareRadioButton1.Selected = this.PostRequestParams.UIDontcareRadioButton1Selected;

            // Select 'Big bag' radio button
            if (bags == Bags.big_bag)
                uIBigbagRadioButton1.Selected = this.PostRequestParams.UIBigbagRadioButton1Selected;

            // Select 'None/Small bag' radio button
            if (bags == Bags.none)
                uINoneSmallbagRadioButton1.Selected = this.PostRequestParams.UINoneSmallbagRadioButton1Selected;

            // Type '2015-07-28' in 'Date' text box
            uIDateEdit1.Text = this.PostRequestParams.UIDateEdit1Text;

            // Type '02:36' in 'postFromTimeInput' text box
            uIPostFromTimeInputEdit1.Text = this.PostRequestParams.UIPostFromTimeInputEdit1Text;

            // Type '02:37' in 'postToTimeInput' text box
            uIPostToTimeInputEdit1.Text = this.PostRequestParams.UIPostToTimeInputEdit1Text;

            // Click 'Post' button
            Mouse.Click(uIPostButton, new Point(68, 12));
        }

        public virtual PostRequestParams PostRequestParams
        {
            get
            {
                if ((this.mPostRequestParams == null))
                {
                    this.mPostRequestParams = new PostRequestParams();
                }
                return this.mPostRequestParams;
            }
        }

        private PostRequestParams mPostRequestParams;

        /// <summary>
        /// Register - Use 'RegisterParams' to pass parameters into this method.
        /// </summary>
        public void Register()
        {
            #region Variable Declarations
            HtmlEdit uIRegFNameEdit = this.UIRideShareWindowsInteWindow.UIRideShareDocument.UIRegFNameEdit;
            HtmlEdit uIRegLNameEdit = this.UIRideShareWindowsInteWindow.UIRideShareDocument.UIRegLNameEdit;
            HtmlEdit uIRegEmailEdit = this.UIRideShareWindowsInteWindow.UIRideShareDocument.UIRegEmailEdit;
            HtmlEdit uIRegPhoneEdit = this.UIRideShareWindowsInteWindow.UIRideShareDocument.UIRegPhoneEdit;
            HtmlEdit uIRegPassEdit = this.UIRideShareWindowsInteWindow.UIRideShareDocument.UIRegPassEdit;
            HtmlEdit uIRegVerPassEdit = this.UIRideShareWindowsInteWindow.UIRideShareDocument.UIRegVerPassEdit;
            HtmlInputButton uIRegisterButton = this.UIRideShareWindowsInteWindow.UIRideShareDocument.UIRegisterContentPane.UIRegisterButton;
            HtmlDiv uIAreYouSureAllDetailsPane = this.UIRideShareWindowsInteWindow.UIRideShareDocument.UIAreYouSureAllDetailsPane;
            HtmlInputButton uIYesButton = this.UIRideShareWindowsInteWindow.UIRideShareDocument.UIYesButton;
            #endregion

            // Type '' in 'regFName' text box
            uIRegFNameEdit.Text = this.RegisterParams.UIRegFNameEditText;

            // Type '' in 'regLName' text box
            uIRegLNameEdit.Text = this.RegisterParams.UIRegLNameEditText;

            // Type '' in 'regEmail' text box
            uIRegEmailEdit.Text = this.RegisterParams.UIRegEmailEditText;

            // Type '' in 'regPhone' text box
            uIRegPhoneEdit.Text = this.RegisterParams.UIRegPhoneEditText;

            // Type '' in 'regPass' text box
            uIRegPassEdit.Text = this.RegisterParams.UIRegPassEditText;

            // Type '' in 'regVerPass' text box
            uIRegVerPassEdit.Text = this.RegisterParams.UIRegVerPassEditText;

            // Click 'Register' button
            Mouse.Click(uIRegisterButton, new Point(35, 29));

            // Set flag to allow play back to continue if non-essential actions fail. (For example, if a mouse hover action fails.)
            Playback.PlaybackSettings.ContinueOnError = true;

            try
            {
                // Mouse hover 'Are You Sure All Details Correct?' pane at (1, 1)
                Mouse.Hover(uIAreYouSureAllDetailsPane, new Point(1, 1));

                // Reset flag to ensure that play back stops if there is an error.
                Playback.PlaybackSettings.ContinueOnError = false;

                // Click 'Yes' button
                Mouse.Click(uIYesButton, new Point(48, 11));
            }
            catch { }
        }

        public virtual RegisterParams RegisterParams
        {
            get
            {
                if ((this.mRegisterParams == null))
                {
                    this.mRegisterParams = new RegisterParams();
                }
                return this.mRegisterParams;
            }
        }

        private RegisterParams mRegisterParams;

        /// <summary>
        /// AddStop - Use 'AddStopParams' to pass parameters into this method.
        /// </summary>
        public void AddStop()
        {
            #region Variable Declarations
            HtmlEdit uIPublishInputEdit1 = this.UIRideShareWindowsInteWindow.UIRideShareDocument.UIPublishInputEdit1;
            #endregion

            // Type 'Haifa, Israel' in 'publishInput' text box
            uIPublishInputEdit1.Text = this.AddStopParams.UIPublishInputEdit1Text;

            Thread.Sleep(2000);
            Keyboard.SendKeys("{Down}");
            Keyboard.SendKeys("{Enter}");
        }

        public virtual AddStopParams AddStopParams
        {
            get
            {
                if ((this.mAddStopParams == null))
                {
                    this.mAddStopParams = new AddStopParams();
                }
                return this.mAddStopParams;
            }
        }

        private AddStopParams mAddStopParams;
    }
    /// <summary>
    /// Parameters to be passed into 'PostRequest'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class PostRequestParams
    {

        #region Fields
        /// <summary>
        /// Type 'beersheba' in 'postInput' text box
        /// </summary>
        public string UIPostInputEditText = "beersheba";

        /// <summary>
        /// Type 'haifa' in 'postInput' text box
        /// </summary>
        public string UIPostInputEdit1Text = "haifa";

        /// <summary>
        /// Select 'No' radio button
        /// </summary>
        public bool UINORadioButton1Selected = true;

        /// <summary>
        /// Select 'Yes' radio button
        /// </summary>
        public bool UIYesRadioButton1Selected = true;

        /// <summary>
        /// Select 'Dont care' radio button
        /// </summary>
        public bool UIDontcareRadioButton1Selected = true;

        /// <summary>
        /// Select 'Big bag' radio button
        /// </summary>
        public bool UIBigbagRadioButton1Selected = true;

        /// <summary>
        /// Select 'None/Small bag' radio button
        /// </summary>
        public bool UINoneSmallbagRadioButton1Selected = true;

        /// <summary>
        /// Type '2015-07-28' in 'Date' text box
        /// </summary>
        public string UIDateEdit1Text = "2015-07-28";

        /// <summary>
        /// Type '02:36' in 'postFromTimeInput' text box
        /// </summary>
        public string UIPostFromTimeInputEdit1Text = "02:36";

        /// <summary>
        /// Type '02:37' in 'postToTimeInput' text box
        /// </summary>
        public string UIPostToTimeInputEdit1Text = "02:37";
        #endregion
    }
    /// <summary>
    /// Parameters to be passed into 'Register'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class RegisterParams
    {

        #region Fields
        /// <summary>
        /// Type '' in 'regFName' text box
        /// </summary>
        public string UIRegFNameEditText = "";

        /// <summary>
        /// Type '' in 'regLName' text box
        /// </summary>
        public string UIRegLNameEditText = "";

        /// <summary>
        /// Type '' in 'regEmail' text box
        /// </summary>
        public string UIRegEmailEditText = "";

        /// <summary>
        /// Type '' in 'regPhone' text box
        /// </summary>
        public string UIRegPhoneEditText = "";

        /// <summary>
        /// Type '' in 'regPass' text box
        /// </summary>
        public string UIRegPassEditText = "";

        /// <summary>
        /// Type '' in 'regVerPass' text box
        /// </summary>
        public string UIRegVerPassEditText = "";
        #endregion
    }
    /// <summary>
    /// Parameters to be passed into 'AddStop'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class AddStopParams
    {

        #region Fields
        /// <summary>
        /// Type 'Haifa, Israel' in 'publishInput' text box
        /// </summary>
        public string UIPublishInputEdit1Text = "haifa";

        /// <summary>
        /// Type '{Enter}' in 'publishInput' text box
        /// </summary>
        public string UIPublishInputEdit1SendKeys = "{Enter}";
        #endregion
}
}
