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
    public class ClassifyProduct
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClassifyId { get; set; }
        [Display(Name = "Product")]
        public int ProductId { get; set; }
        public string? Contents { get; set; }
        public string Picture { get; set; }
        public DateTime DateCreate { get; set; }
        [NotMapped]
        [JsonIgnore]
        public IFormFile? SelectImage { get; set; }
        [JsonIgnore]
        public virtual Product? Product { get; set; }
    }
}
