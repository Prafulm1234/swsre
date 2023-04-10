ï»¿using System;
using System.Collections.Generic;

namespace swsre.Models
{
    public partial class Tpolicycoveragedetail
    {
        public Tpolicycoveragedetail()
        {
            Tamounts = new HashSet<Tamount>();
            Tdeductions = new HashSet<Tdeduction>();
        }

        public int PcdId { get; set; }
        public int PolicyId { get; set; }
        public int? PolicyperiodId { get; set; }
        public string Policyrecord { get; set; }
        public string Policyperiodrecord { get; set; }
        public int? Coverageid { get; set; }

        public virtual Tpolicy Policy { get; set; }
        public virtual Tpolicyperiod Policyperiod { get; set; }
        public virtual ICollection<Tamount> Tamounts { get; set; }
        public virtual ICollection<Tdeduction> Tdeductions { get; set; }
    }
}
