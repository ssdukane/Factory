using System;
using System.Collections.Generic;
using System.Text;

namespace Factory.Business
{
    public class DTO
    {
        public int Id { get; set; }
        public int RequestType { get; set; }
        public bool IsEncrypted { get; set; }
        public string Data { get; set; }
    }
}
