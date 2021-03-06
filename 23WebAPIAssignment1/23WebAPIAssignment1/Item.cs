//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _23WebAPIAssignment1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            this.PoDetails = new HashSet<PoDetail>();
        }

        [Required]
        [StringLength(4, ErrorMessage = "String length can be max 4")]
        [DisplayName("Item code")]
        public string ItCode { get; set; }
        [Required]
        [DisplayName("Item Description")]
        public string ItDesc { get; set; }
        [Required]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Item Rate invalid")]
        [DisplayName("Item Rate")]
        public Nullable<decimal> ItRate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PoDetail> PoDetails { get; set; }
    }
}
