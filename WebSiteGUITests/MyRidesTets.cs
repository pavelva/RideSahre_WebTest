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
    public class MyRidesTets : RideShareWebSiteTests
    {
        private PostRequest request;
        private PublishRide ride;

        public MyRidesTets()
        {
            this.request = new PostRequest();
            this.ride = new PublishRide();
        }

        [TestMethod]
        public void DeleteRequestBtn()
        {
            PublishNewRequest();

            adapter.Delete();
            assert.MessageAssertion(this.data.deleteRequest);
        }

        [TestMethod]
        public void DeleteRequest()
        {
            PublishNewRequest();
            string id = adapter.GetFirstRideId();

            adapter.Delete();
            adapter.Approve();
            assert.AssertRideNotExist(id);
        }

        [TestMethod]
        public void DeleteRideBtn()
        {
            PublishNewRide();

            adapter.Delete();
            assert.MessageAssertion(this.data.deleteRide);
        }

        

        [TestMethod]
        public void DeleteRide()
        {
            PublishNewRide();

            string id = adapter.GetFirstRideId();
            adapter.Delete();
            adapter.Approve();
            assert.AssertRideNotExist(id);
        }

        protected override void TestInitialize()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            adapter.Login(data.CorrectEmail, data.CorrectPassword);
        }

        private void PublishNewRequest()
        {
            adapter.GoToPostRequest();
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
        }

        private void PublishNewRide()
        {
            adapter.GoToPublishRide();
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            ride.Clear();
            ride.source = "tel aviv";
            ride.destination = "kiryat shmona";
            ride.setDate(day, month, year);
            ride.fromTime = "14:00";
            ride.toTime = "15:00";
            ride.price = "100";
            ride.maxPassengers = "4";
            adapter.PublishRide(ride);
        }
    }
}
