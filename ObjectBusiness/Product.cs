using Microsoft.AspNetCore.Http;
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
    public class Product
    {
        // Record in table product
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "Product name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Product description")]
        public string ProductDescription { get; set; }
        public string Voucher { get; set; }
        public int Sold { get; set; }
        public int Inventory { get; set; }
        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        public decimal Evaluate { get; set; }
        public int Liked { get; set; }
        [Required]
        [Display(Name = "Picture")]
        public string Picture { get; set; }
        [Display(Name = "Date post")]
        public DateTime DatePost { get; set; } = DateTime.Now;
        [NotMapped]
        [JsonIgnore]
        public IFormFile SelectImage { get; set; } // Upload image

        // Relationship with product category
        [JsonIgnore]
        public virtual ProductCategory? Category { get; set; } // 1 - n -> n
        [JsonIgnore]
        public virtual ICollection<ClassifyProduct>? ClassifyProducts { get; set; }
    }
}
