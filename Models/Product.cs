using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sport_shop.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }



        public ICollection<Cart> Carts { get; set; }
        public ICollection<Bagpack> Bagpacks { get; set; }
        public ICollection<Bicycle> Bicycles { get; set; }
        public ICollection<Football> Footballs { get; set; }
        public ICollection<Shoe> Shoes { get; set; }

    }
}
