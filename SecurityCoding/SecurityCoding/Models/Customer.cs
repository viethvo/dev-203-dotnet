using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityCoding.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [AllowHtml]
        public string Adress { get; set; }
        public int Age { get; set; }
        public string Image { get; set; } = string.Empty;
    }
}