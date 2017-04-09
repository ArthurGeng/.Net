using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;



namespace Shop.Models.Entities
{
    public class ProductDetail
    {
        public int Id { get; set; }
        // Foreign Key
        public int ProductId { get; set; }
        // Navigation property
        public Product Product { get; set; }
        [Required]
        public String ProductCompany { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
    }
}