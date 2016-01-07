using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Process.Models
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public Domain domain { get; set; }
    }
}