using System;
using System.Collections.Generic;
using System.Text;

namespace Omi.Application.Configuration
{
    public class ApplicationOptions
    {
        public new  ConnectionStringsConfig ConnectionStrings { get; set; }
        public AppSettings AppSettings { get; set; }
    }
}
