ï»¿using System;
using System.Collections.Generic;

namespace swsre.Models
{
    public partial class VCatalog
    {
        public int CatalogId { get; set; }
        public string CatalogName { get; set; }
        public int Id { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public string Codetype { get; set; }
    }
}
