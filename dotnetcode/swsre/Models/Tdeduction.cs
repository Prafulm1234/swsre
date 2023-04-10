ï»¿using System;
using System.Collections.Generic;

namespace swsre.Models
{
    public partial class Tdeduction
    {
        public int DeductionId { get; set; }
        public int PcdId { get; set; }
        public int Deductiongroup { get; set; }
        public int Deductioncode { get; set; }
        public int Deductionbasis { get; set; }
        public int DeductionP { get; set; }
        public int DeductionFlatamount { get; set; }
        public int DeductionBasisamount { get; set; }

        public virtual Tpolicycoveragedetail Pcd { get; set; }
    }
}
