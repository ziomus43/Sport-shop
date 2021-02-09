using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sport_shop.Models
{
    public class Shoe
    {
        [Key]
        public int ShoeID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }

    }
}
