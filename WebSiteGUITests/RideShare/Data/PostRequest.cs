using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteGUITests.RideShare.Data
{
    public class PostRequest:Publish
    {
        private bool[] _bags;

        public PostRequest():base()
        {
        }

        protected override void classInit()
        {
            setBags(Bags.none);
        }        

        public void setBags(Bags b){
            this._bags = new bool[2]{false, false};
            this._bags[(int)b] = true;
        }

        public Bags bags
        {
            get
            {
                return this._bags[0] ? Bags.big_bag : Bags.none;
            }
        }
    }
}
