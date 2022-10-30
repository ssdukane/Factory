using System;

namespace Omi.Domain.Entities
{
    public partial class Owner
    {
        public Guid Id { get; set; } 
        public string  FirstName { get; set; } 
        public string  LastName { get; set; } 
        public string  BusinessName { get; set; } 
        public string  DisplayName { get; set; } 
        public string  Mobile { get; set; } 
    }
}
