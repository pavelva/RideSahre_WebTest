using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteGUITests.RideShare.Data
{
    public class PostRequest:Publish
    {
        public Bags bags;

        public PostRequest():base()
        {
        }

        protected override void classInit()
        {
            this.bags = Bags.none;
        }                
    }
}
