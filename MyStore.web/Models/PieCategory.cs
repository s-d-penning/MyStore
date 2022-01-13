using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyStore.web.Models
{
    public partial class PieCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Pie> Pies { get; set; }
    }
}