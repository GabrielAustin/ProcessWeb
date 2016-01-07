using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Process.Models
{
    public class Basket
    {
        public int pType { get; set; }
        public int pFrom { get; set; }
        public int pNudoc { get; set; }
        public int pWfp { get; set; }
        public int pWfa { get; set; }
        public string pFrom_date { get; set; }
        public string pTo_date { get; set; }
        public string pDetail { get; set; }

        public Basket()
        {
            pType = 0;
            pFrom = 0;
            pNudoc = 0;
            pWfp = 0;
            pWfa = 0;
            pFrom_date = "";
            pTo_date = "";
            pDetail = "";
        }

        public Basket(int id)
        {
            pType = id;
            pFrom = 0;
            pNudoc = 0;
            pWfp = 0;
            pWfa = 0;
            pFrom_date = "";
            pTo_date = "";
            pDetail = "";
        }
    }
}