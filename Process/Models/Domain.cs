using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Process.Models
{
    public class Domain
    {
        public string name { get; set; }
        public string language { get; set; }
        public int connectionType { get; set; }
        public int securityLevel { get; set; }
        public string webEnvironment { get; set; }
    }
}