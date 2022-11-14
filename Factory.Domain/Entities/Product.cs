using System;

namespace Omi.Domain.Entities
{
    public partial class Product
    {
        public int Id { get; set; } 
        public string  Name { get; set; }
        public string DisplayName { get; set; }
        public string  BusinessOf { get; set; } 
        
    }
}
