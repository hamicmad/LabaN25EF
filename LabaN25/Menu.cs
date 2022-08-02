using System;
using System.Collections.Generic;

namespace LabaN25
{
    public partial class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public byte[]? Photo { get; set; }
        public decimal Price { get; set; }
        public string Decribe { get; set; } = null!;
        public string Category { get; set; } = null!;
    }
}
