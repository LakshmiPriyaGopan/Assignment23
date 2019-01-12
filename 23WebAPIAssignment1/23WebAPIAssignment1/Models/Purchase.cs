using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _23WebAPIAssignment1.Models
{
    public class Purchase
    {
        [Required]
        [DisplayName("Purchase No")]
        public string PoNo { get; set; }
        [Required]
        [DisplayName("Purchase Date")]
        public Nullable<System.DateTime> PoDate { get; set; }
        [Required]
        [DisplayName("Supplier No")]
        public string SuplNo { get; set; }

        [Required]
        [DisplayName("Item's Code")]
        public string Itcode { get; set; }
        [Required]
        [DisplayName("Quanitity")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Quantity must be numeric")]
        public Nullable<int> Qty { get; set; }
    }
}