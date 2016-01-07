using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Process.Models
{
    public class BasketModel
    {
        public int type { get; set; }
        public int from { get; set; }
        public int docNumber { get; set; }
        public int wfParent { get; set; }
        public int wfChild { get; set; }
        public string dateStart { get; set; }
        public string dateEnd { get; set; }
        public string detail { get; set; }
    }
}