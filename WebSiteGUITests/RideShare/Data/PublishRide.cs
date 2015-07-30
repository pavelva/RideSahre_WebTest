using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteGUITests.RideShare.Data
{
    public class PublishRide : Publish
    {
        public string[] stops;
        public string maxPassengers;
        public string price;

        public PublishRide():base()
        {
        }

        protected override void classInit()
        {
            this.stops = new string[4] {"","","","" };
            this.maxPassengers = "4";
            this.price = "60";
        }

        public override void Clear()
        {
            base.Clear();
            this.maxPassengers = "";
            this.price = "";
        }
    }
}
