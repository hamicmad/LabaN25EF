using System;
using System.Collections.Generic;

namespace LabaN25
{
    public partial class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TableNumber { get; set; }
        public string WaiterName { get; set; } = null!;
    }
}
