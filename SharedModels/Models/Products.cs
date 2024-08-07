﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SharedModels.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Categories Category { get; set; }
    }
}
