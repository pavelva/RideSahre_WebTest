using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteGUITests.RideShare.Data
{
    public enum Smoking
    {
        yes, no, dontCare
    }

    public enum Bags
    {
        big_bag, none
    }

    public abstract class Publish
    {
        public string source;
        public string destination;
        public string fromTime;
        public string toTime;
        public Smoking smoking;

        protected string _date;

        public Publish()
        {
            init();
        }

        public void init()
        {
            this.source = "";
            this.destination = "";
            this._date = "";
            this.fromTime = "";
            this.toTime = "";
            this.smoking = Smoking.dontCare;

            classInit();
        }

        protected abstract void classInit();

        public string date
        {
            get
            {
                return _date;
            }
        }

        public void setDate(int day, int month, int year)
        {
            this._date = year + "-" + (month < 10 ? "0" : "") + month + "-" + (day < 10 ? "0" : "") + day;
        }

        public virtual void Clear()
        {
            init();
        }
    }
}
