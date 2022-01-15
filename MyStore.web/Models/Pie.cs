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

        [Required(ErrorMessage = "The name cannot be blank")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Please enter a name between 3 and 50 characters in length")]
        [RegularExpression(@"^[a-zA-Z0-9'-'\s]*$", ErrorMessage = "Please enter a name made up of letters and numbers only")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The description cannot be blank")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Please enter a description between 10 and 200 characters in length")]
        [RegularExpression(@"^[,;a-zA-Z0-9'-'\s]*$", ErrorMessage = "Please enter a description made up of letters and numbers numbers only")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The price cannot be blank")]
        [Range(0.10, 10000, ErrorMessage = "Please enter a price between 0.10 and 10000.00")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [RegularExpression("[0-9]+(\\.[0-9][0-9]?)?", ErrorMessage = "The price must be a number up to two decimal places")]
        public decimal Price { get; set; }

        public int? PieCategoryID { get; set; }

        public virtual PieCategory Category { get; set; }
    }
}