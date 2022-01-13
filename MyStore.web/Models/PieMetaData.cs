using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyStore.web.Models
{
    [MetadataType(typeof(PieMetaData))]
    public partial class Pie
    {
    }
    public class PieMetaData
    {
        [Display(Name = "Pie")]
        public string Name;
    }
}