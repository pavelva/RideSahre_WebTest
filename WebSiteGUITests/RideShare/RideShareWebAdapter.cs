using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITesting;
using WebSiteGUITests.RideShare.Data;

namespace WebSiteGUITests.RideShare
{
    public class RideShareWebAdapter
    {
        public UIMap UIMap;

        public RideShareWebAdapter(UIMap UIMap)
        {
            this.UIMap = UIMap;
        }

        public void Login(string email, string password)
        {
            this.UIMap.LoginParams.UILoginEmailEditText = email;
            this.UIMap.LoginParams.UILoginPassEditPassword = Playback.EncryptText(password);

            this.UIMap.Login();
        }

        public void Logout()
        {
            this.UIMap.Logout();
        }
        public void StartRideShare()
        {
            this.UIMap.StartRideShare();
        }

        public void CloseBrowser()
        {
            this.UIMap.CloseInternetExplorer();

            try
            {
                this.UIMap.CloseAllTabs();
            }
            catch { }
        }


        public void ClosePopup()
        {
            this.UIMap.ClosePopup();
        }

        public void OpenRegisterPanel()
        {
            this.UIMap.OpenRegisterPanel();
        }

        public void Register(Register registerObj)
        {
            this.UIMap.RegisterParams.UIRegFNameEditText = registerObj.firstName;
            this.UIMap.RegisterParams.UIRegLNameEditText = registerObj.lastName;
            this.UIMap.RegisterParams.UIRegEmailEditText = registerObj.email;
            this.UIMap.RegisterParams.UIRegPhoneEditText = registerObj.phone;
            this.UIMap.RegisterParams.UIRegPassEditText = (registerObj.password == "" ? "" :Playback.EncryptText(registerObj.password));
            this.UIMap.RegisterParams.UIRegVerPassEditText = (registerObj.verifiedPassword == ""? "" : Playback.EncryptText(registerObj.verifiedPassword));
            this.UIMap.Register();
        }

        internal void GoToSearchRide()
        {
            this.UIMap.GoToSearchRide();
        }

        internal void GoToPublishRide()
        {
            this.UIMap.GoToPublishRide();
        }

        internal void GoToPostRequest()
        {
            this.UIMap.GoToPostRequest();
        }

        internal void GoToMyRides()
        {
            this.UIMap.GoToMyRides();
        }

        internal void GoToHome()
        {
            this.UIMap.GoToHome();
        }
    }
}
