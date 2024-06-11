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
    public class Shop
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Shop ID")]
        public int ShopId { get; set; }
        [Required]
        [Display(Name = "Shop name")]
        public string ShopName { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Picture { get; set; }
        [Required]
        public string ShopDescription { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        public decimal Evaluate { get; set; }
        [Display(Name = "Date register")]
        public DateTime DateRegister { get; set; } = DateTime.Now;
        [JsonIgnore]
        [NotMapped]
        public IFormFile? SelectImage { get; set; } // Upload image

        // Relationship with product category
        [JsonIgnore]
        public virtual ICollection<ProductCategory>? ProductCategories { get; set; } // 1 - n -> 1
    }
}
