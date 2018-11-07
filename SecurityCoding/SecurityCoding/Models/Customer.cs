using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityCoding.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Adress { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter value bigger than {1}")]
        public int Age { get; set; }
        public string Image { get; set; } = string.Empty;
    }
}