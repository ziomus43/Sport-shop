using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Sport_shop.Areas.Identity.Data;

namespace Sport_shop.Models
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
        [PersonalData]
        public string Name { get; set; }
        [PersonalData]
        public string Surname { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }

    }
}
