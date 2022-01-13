using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyStore.web.Models
{
    public partial class Pie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? PieCategoryID { get; set; }
        public virtual PieCategory Category { get; set; }
    }
}