using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Sport_shop.Models;

namespace Sport_shop.Areas.Identity.Data
{
    public class ApplicationUser 
    {
        [Key]
        public int ApplicationUserID { get; set; }
        [PersonalData]
        public string Login { get; set; }
        [PersonalData]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [PersonalData]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email address")]
        public string EmailAddress { get; set; }

        public int ClientID { get; set; }
        public Client Client { get; set; }

    }
}
