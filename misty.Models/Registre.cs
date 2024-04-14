﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace misty.Models {
    public class Registre {
        public string? Name { get; set; }
        public string? Email { get; set; }

        public string Password { get; set; }

        [Compare("Password",ErrorMessage= "Password dont match")]
        public string? ConfirmPassword { get; set; }
        public string? Address { get; set; }

    
    }
}

