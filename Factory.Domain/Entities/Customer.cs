using System;

namespace Omi.Domain.Entities
{
    public partial class Customer
    {
        public Guid Id { get; set; } 
        public string  FirstName { get; set; } 
        public string  LastName { get; set; } 
        public string  CustomerOf { get; set; } 
        public string  DisplayName { get; set; } 
        public string  Mobile { get; set; } 
    }
}
