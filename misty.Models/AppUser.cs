using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace misty.Models {
    public class AppUser :IdentityUser {

        [StringLength(100)]
        [MaxLength(100)]

        public string? adresse { get; set; }
        public string?  name { get; set; }

    }
}
