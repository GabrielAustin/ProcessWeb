using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Process.Models
{
    public class UserModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public DomainModel domain { get; set; }
    }
}