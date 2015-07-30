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
    public class PublishRideTests : RideShareWebSiteTests
    {
        private PublishRide ride;

        public PublishRideTests()
        {
            this.ride = new PublishRide();
        }

        [TestMethod]
        public void PublishRideEmptyFields()
        {
            ride.Clear();

            adapter.PublishRide(ride);

            assert.MessageAssertion(data.BadSource);
        }

        [TestMethod]
        public void PublishRideEmptyFields_AllBut_Source()
        {
            ride.Clear();
            ride.source = "telaviv";
            adapter.PublishRide(ride);

            assert.MessageAssertion(data.BadDestination);
        }

        [TestMethod]
        public void PublishRideEmptyFields_AllBut_Source_Destination()
        {
            ride.Clear();
            ride.source = "tel aviv";
            ride.destination = "kiryat shmona";
            adapter.PublishRide(ride);

            assert.MessageAssertion(data.BadDate);
        }

        [TestMethod]
        public void PublishRideEmptyFields_AllBut_Source_Destination_Date()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            ride.Clear();
            ride.source = "tel aviv";
            ride.destination = "kiryat shmona";
            ride.setDate(day, month, year);
            adapter.PublishRide(ride);

            assert.MessageAssertion(data.BadTimeInterval);
        }

        [TestMethod]
        public void PublishRideEmptyFields_AllBut_Source_Destination_Date_FromTime()
        {
            DateTime now = DateTime.Now.AddYears(1);
            var year = now.Year;
            var month = now.Month;
            var day = now.Day;

            ride.Clear();
            ride.source = "tel aviv";
            ride.destination = "kiryat shmona";
            ride.setDate(day, month, year);
            ride.fromTime = "14:00";
            adapter.PublishRide(ride);

            assert.MessageAssertion(data.BadTimeInterval);
        }

        [TestMethod]
        public void PublishRideEmptyFields_AllBut_Source_Destination_Date_FromTime_ToTime()
        {
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
            adapter.PublishRide(ride);

            assert.MessageAssertion(data.BadPrice);
        }

        [TestMethod]
        public void PublishRideEmptyFields_AllBut_Source_Destination_Date_FromTime_ToTime_Price()
        {
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
            adapter.PublishRide(ride);

            assert.MessageAssertion(data.BadPassengersAmount);
        }

        [TestMethod]
        public void PublishRideAllCorrectNoStops()
        {
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

            assert.AssertMyRidesPage();
        }
        //[TestMethod]
        //public void CodedUITestMethod1()
        //{
        //    adapter.AddStop("haifa");
        //    adapter.AddStop("telaviv");
        //    adapter.AddStop("beersheva");

        //    string first = adapter.GetStop(1);
        //    string second = adapter.GetStop(2);
        //    string third = adapter.GetStop(3);

        //    assert.AssertStop(1, first);
        //    assert.AssertStop(2, second);
        //    assert.AssertStop(3, third);

        //    adapter.DeleteStop(2);
        //    assert.AssertStop(1, first);
        //    assert.AssertStop(2, third);
        //}

        protected override void TestInitialize()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            adapter.Login(data.CorrectEmail, data.CorrectPassword);
            adapter.GoToPublishRide();
        }
    }
}
