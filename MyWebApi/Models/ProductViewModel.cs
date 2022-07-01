using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Models
{
    public class ProductViewModel
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Descrpiption { get; set; }
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        public byte Discount { get; set; }
        public int? CategoryID { get; set; }
    }
}
