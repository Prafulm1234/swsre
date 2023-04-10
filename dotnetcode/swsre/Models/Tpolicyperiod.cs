ï»¿using System;
using System.Collections.Generic;

namespace swsre.Models
{
    public partial class Tpolicyperiod
    {
        public Tpolicyperiod()
        {
            Tpolicycoveragedetails = new HashSet<Tpolicycoveragedetail>();
        }

        public int PolicyperiodId { get; set; }
        public int PolicyId { get; set; }
        public string PolicyperiodseqNo { get; set; }
        public DateTime Effectivedate { get; set; }
        public DateTime Expirationdate { get; set; }

        public virtual Tpolicy Policy { get; set; }
        public virtual ICollection<Tpolicycoveragedetail> Tpolicycoveragedetails { get; set; }
    }
}
