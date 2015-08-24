using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITesting;
using WebSiteGUITests.RideShare.Data;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

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

            Thread.Sleep(2000);
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
            Thread.Sleep(500);
        }

        internal void GoToPublishRide()
        {
            this.UIMap.GoToPublishRide();
            Thread.Sleep(500);
        }

        internal void GoToPostRequest()
        {
            this.UIMap.GoToPostRequest();
            Thread.Sleep(500);
        }

        internal void GoToMyRides()
        {
            this.UIMap.GoToMyRides();
            Thread.Sleep(500);
        }

        internal void GoToHome()
        {
            this.UIMap.GoToHome();
            Thread.Sleep(500);
        }

        public void PostRequest(PostRequest request)
        {
            var args = this.UIMap.PostRequestParams;

            args.UIPostInputEditText = request.source;
            args.UIPostInputEdit1Text = request.destination;

            args.UIYesRadioButton1Selected = true;
            args.UINORadioButton1Selected = true;
            args.UIDontcareRadioButton1Selected = true;

            args.UIBigbagRadioButton1Selected = true;
            args.UINoneSmallbagRadioButton1Selected = true;

            args.UIDateEdit1Text = request.date;
            args.UIPostFromTimeInputEdit1Text = request.fromTime;
            args.UIPostToTimeInputEdit1Text = request.toTime;

            this.UIMap.PostRequest(request.smoking, request.bags);
        }

        public void AddStop(string stop)
        {
            this.UIMap.AddStopParams.UIPublishInputEdit1Text = stop;

            this.UIMap.AddStop();
        }

        public string GetStop(int position)
        {
            switch (position)
            {
                case 1:
                    return this.UIMap.GetFirstStop();
                case 2:
                    return this.UIMap.GetSecondStop();
                case 3:
                    return this.UIMap.GetThridStop();
                case 4:
                    return this.UIMap.GetFourthStop();
                case 5:
                    return this.UIMap.GetFifthStop();
                default:
                    throw new Exception("Bad Arguments");
            }
        }

        public void DeleteStop(int position)
        {
            switch (position)
            {
                case 1:
                    this.UIMap.DeleteFirstStop();
                    break;
                case 2:
                    this.UIMap.DeleteSecondStop();
                    break;
                case 3:
                    this.UIMap.DeleteThirdStop();
                    break;
                case 4:
                    this.UIMap.DeleteFourthStop();
                    break;
                case 5:
                    this.UIMap.DeleteFifthStop();
                    break;
                default:
                    throw new Exception("Bad Arguments");
            }
        }

        public void PublishRide(PublishRide ride)
        {
            this.UIMap.PublishRideParams.UIPublishInputEditText = ride.source;
            this.UIMap.PublishRideParams.UIPublishInputEdit11Text = ride.destination;

            this.UIMap.PublishRideParams.UIDateEdit2Text = ride.date;
            this.UIMap.PublishRideParams.UIPublishFromTimeInputEditText = ride.fromTime;
            this.UIMap.PublishRideParams.UIPublishToTimeInputEditText = ride.toTime;

            this.UIMap.PublishRideParams.UIPostInputEdit2Text = ride.maxPassengers;
            this.UIMap.PublishRideParams.UIPublishInputEdit2Text = ride.price;

            this.UIMap.PublishRide(ride.smoking);
        }

        public void Delete()
        {
            this.UIMap.DeleteBtn();
        }

        public void Approve()
        {
            this.UIMap.Approve();
        }

        public string GetFirstRideId()
        {
            var ridesPanel = this.UIMap.UIRideShareWindowsInteWindow.UIRideShareDocument.UIRidesPane1.MyRidesPanel;
            var firstRide  = ridesPanel.GetChildren()[0];
            return ((HtmlDiv)(firstRide)).Id;
        }
    }
}
