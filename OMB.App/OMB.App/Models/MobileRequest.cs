using System;
using System.Collections.Generic;
using System.Text;

namespace OMB.App.Models
{

    public class MobileRequest
    {
        public int id { get; set; }
        public int requestType { get; set; }
        public bool isEncrypted { get; set; }
        public string data { get; set; }
    }

}

