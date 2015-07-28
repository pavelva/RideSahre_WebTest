using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteGUITests.Assertions
{
    public enum Page
    {
        home, searchRide, postRequest, publishRide, myRides
    }

    public class PageAssertions
    {
        public string homeLink { get; private set; }
        public string searchRideLink { get; private set; }
        public string publishRideLink { get; private set; }
        public string postRequestLink { get; private set; }
        public string myRidesLink { get; private set; }
        public string homePanel { get; private set; }
        public string myRidesPanel { get; private set; }
        public string searchRidePanel { get; private set; }
        public string postRequestPanel { get; private set; }
        public string punlishRidePanel { get; private set; }

        public PageAssertions(Page page)
        {
            switch (page)
            {
                case Page.home:
                    initHomePage();
                    break;
                case Page.myRides:
                    initMyRidesPage();
                    break;
                case Page.postRequest:
                    initPostRequestPage();
                    break;
                case Page.publishRide:
                    initPublishRidePage();
                    break;
                case Page.searchRide:
                    initSearchRidePage();
                    break;
                default:
                    throw new ArgumentException("Bad Page Received");
            }
            
        }

        private void initSearchRidePage()
        {
            this.homeLink = "id=\"aHome\" style=\"color: white;\" onclick=\"updateCurrentPage(pages.hom" + "e)\"";
            this.searchRideLink = "id=\"aSearchRide\" style=\"color: rgb(237, 192, 56);\" onclick=\"updateCurrentPage(pages.searchRides)\"";
            this.publishRideLink = "id=\"aPublishRide\" style=\"color: white;\" onclick=\"updateCurrentPage(pages.publishRide)\"";
            this.postRequestLink = "id=\"aPostRequest\" style=\"color: white;\" onclick=\"updateCurrentPage(pages.postRequest)\"";
            this.myRidesLink = "id=\"aMyRides\" style=\"color: white;\" onclick=\"updateCurrentPage(pages.myRides)\"";
            this.homePanel = "class=\"mainContent\" id=\"home\" style=\"display: none;\"";
            this.myRidesPanel = "class=\"mainContent\" id=\"myRides\" style=\"display: none;\"";
            this.searchRidePanel = "class=\"mainContent\" id=\"searchRide\" style=\"display: block;\"";
            this.postRequestPanel = "class=\"mainContent container\" id=\"postRequest\" style=\"display: none;\"";
            this.punlishRidePanel = "class=\"mainContent container\" id=\"publishRide\" style=\"display: none;\"";
        }

        private void initPublishRidePage()
        {
            this.homeLink = "id=\"aHome\" style=\"color: white;\" onclick=\"updateCurrentPage(pages.hom" + "e)\"";
            this.searchRideLink = "id=\"aSearchRide\" style=\"color: white;\" onclick=\"updateCurrentPage(pages.searchRides)\"";
            this.publishRideLink = "id=\"aPublishRide\" style=\"color: rgb(237, 192, 56);\" onclick=\"updateCurrentPage(pages.publishRide)\"";
            this.postRequestLink = "id=\"aPostRequest\" style=\"color: white;\" onclick=\"updateCurrentPage(pages.postRequest)\"";
            this.myRidesLink = "id=\"aMyRides\" style=\"color: white;\" onclick=\"updateCurrentPage(pages.myRides)\"";
            this.homePanel = "class=\"mainContent\" id=\"home\" style=\"display: none;\"";
            this.myRidesPanel = "class=\"mainContent\" id=\"myRides\" style=\"display: none;\"";
            this.searchRidePanel = "class=\"mainContent\" id=\"searchRide\" style=\"display: none;\"";
            this.postRequestPanel = "class=\"mainContent container\" id=\"postRequest\" style=\"display: none;\"";
            this.punlishRidePanel = "class=\"mainContent container\" id=\"publishRide\" style=\"display: block;\"";
        }

        private void initPostRequestPage()
        {
            this.homeLink = "id=\"aHome\" style=\"color: white;\" onclick=\"updateCurrentPage(pages.hom" + "e)\"";
            this.searchRideLink = "id=\"aSearchRide\" style=\"color: white;\" onclick=\"updateCurrentPage(pages.searchRides)\"";
            this.publishRideLink = "id=\"aPublishRide\" style=\"color: white;\" onclick=\"updateCurrentPage(pages.publishRide)\"";
            this.postRequestLink = "id=\"aPostRequest\" style=\"color: rgb(237, 192, 56);\" onclick=\"updateCurrentPage(pages.postRequest)\"";
            this.myRidesLink = "id=\"aMyRides\" style=\"color: white;\" onclick=\"updateCurrentPage(pages.myRides)\"";
            this.homePanel = "class=\"mainContent\" id=\"home\" style=\"display: none;\"";
            this.myRidesPanel = "class=\"mainContent\" id=\"myRides\" style=\"display: none;\"";
            this.searchRidePanel = "class=\"mainContent\" id=\"searchRide\" style=\"display: none;\"";
            this.postRequestPanel = "class=\"mainContent container\" id=\"postRequest\" style=\"display: block;\"";
            this.punlishRidePanel = "class=\"mainContent container\" id=\"publishRide\" style=\"display: none;\"";
        }

        private void initMyRidesPage()
        {
            this.homeLink = "id=\"aHome\" style=\"color: white;\" onclick=\"updateCurrentPage(pages.hom" + "e)\"";
            this.searchRideLink = "id=\"aSearchRide\" style=\"color: white;\" onclick=\"updateCurrentPage(pages.searchRides)\"";
            this.publishRideLink = "id=\"aPublishRide\" style=\"color: white;\" onclick=\"updateCurrentPage(pages.publishRide)\"";
            this.postRequestLink = "id=\"aPostRequest\" style=\"color: white;\" onclick=\"updateCurrentPage(pages.postRequest)\"";
            this.myRidesLink = "id=\"aMyRides\" style=\"color: rgb(237, 192, 56);\" onclick=\"updateCurrentPage(pages.myRides)\"";
            this.homePanel = "class=\"mainContent\" id=\"home\" style=\"display: none;\"";
            this.myRidesPanel = "class=\"mainContent\" id=\"myRides\" style=\"display: block;\"";
            this.searchRidePanel = "class=\"mainContent\" id=\"searchRide\" style=\"display: none;\"";
            this.postRequestPanel = "class=\"mainContent container\" id=\"postRequest\" style=\"display: none;\"";
            this.punlishRidePanel = "class=\"mainContent container\" id=\"publishRide\" style=\"display: none;\"";
        }

        private void initHomePage()
        {
            this.homeLink = "id=\"aHome\" style=\"color: rgb(237, 192, 56);\" onclick=\"updateCurrentPage(pages.hom" + "e)\"";
            this.searchRideLink = "id=\"aSearchRide\" style=\"color: white;\" onclick=\"updateCurrentPage(pages.searchRides)\"";
            this.publishRideLink = "id=\"aPublishRide\" style=\"color: white;\" onclick=\"updateCurrentPage(pages.publishRide)\"";
            this.postRequestLink = "id=\"aPostRequest\" style=\"color: white;\" onclick=\"updateCurrentPage(pages.postRequest)\"";
            this.myRidesLink = "id=\"aMyRides\" style=\"color: white;\" onclick=\"updateCurrentPage(pages.myRides)\"";
            this.homePanel = "class=\"mainContent\" id=\"home\" style=\"display: block;\"";
            this.myRidesPanel = "class=\"mainContent\" id=\"myRides\" style=\"display: none;\"";
            this.searchRidePanel = "class=\"mainContent\" id=\"searchRide\" style=\"display: none;\"";
            this.postRequestPanel = "class=\"mainContent container\" id=\"postRequest\" style=\"display: none;\"";
            this.punlishRidePanel = "class=\"mainContent container\" id=\"publishRide\" style=\"display: none;\"";
        }
    }
}
