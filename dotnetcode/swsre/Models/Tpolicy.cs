ï»¿using System;
using System.Collections.Generic;

namespace swsre.Models
{
    public partial class Tpolicy
    {
        public Tpolicy()
        {
            Tpolicycoveragedetails = new HashSet<Tpolicycoveragedetail>();
            Tpolicyperiods = new HashSet<Tpolicyperiod>();
        }

        public int PolicyId { get; set; }
        public int? PriorPolicyId { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime? Inceptiondate { get; set; }
        public DateTime? Expirationdate { get; set; }
        public int? Activitystatuscode { get; set; }
        public string Historyflag { get; set; }
        public string Verifyflag { get; set; }

        public virtual ICollection<Tpolicycoveragedetail> Tpolicycoveragedetails { get; set; }
        public virtual ICollection<Tpolicyperiod> Tpolicyperiods { get; set; }
    }
}
