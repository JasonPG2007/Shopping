using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ObjectBusiness
{
    public class ProductCategory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "Category name")]
        public string CategoryName { get; set; }
        [Required]
        public string? Description { get; set; }
        [Display(Name = "Date create")]
        public DateTime DateCreate { get; set; } = DateTime.Now;

        // Relationship with product
        [JsonIgnore]
        public ICollection<Product>? Products { get; set; } // 1 - n -> 1
    }
}
