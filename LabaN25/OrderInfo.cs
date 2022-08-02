using System;
using System.Collections.Generic;

namespace LabaN25
{
    public partial class OrderInfo
    {
        public int OrderInfoId { get; set; }
        public int MenuPositionId { get; set; }
        public int Amount { get; set; }
        public decimal OrderSum { get; set; }

        public virtual Menu MenuPosition { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
