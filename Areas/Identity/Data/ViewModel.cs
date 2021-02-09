using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sport_shop.Models;

namespace Sport_shop.Areas.Identity.Data
{
    public class ViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public Client Client { get; set; }
    }
}
