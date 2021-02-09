using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sport_shop.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }
        [DisplayName("Product Name")]
        public string Product_Name { get; set; }
        [DisplayName("Model Name")]
        public string Model_Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int ProductID { get; set; }
        public int ClientID { get; set; }
        public Product Product { get; set; }
        public Client Client { get; set; }
        


    }
}
