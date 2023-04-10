ï»¿using System;
using System.Collections.Generic;

namespace swsre.Models
{
    public partial class Tamount
    {
        public int AmountId { get; set; }
        public int PcdId { get; set; }
        public int AmountTypeId { get; set; }
        public decimal Amount { get; set; }

        public virtual Tpolicycoveragedetail Pcd { get; set; }
    }
}
