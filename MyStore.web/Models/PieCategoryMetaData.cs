using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyStore.web.Models
{
    [MetadataType(typeof(PieCategoryMetaData))]
    public partial class PieCategory
    {
    }
    public class PieCategoryMetaData
    {
        [Display(Name = "Pie Category")]
        public string Name;
    }
}