using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace misty.Models {
    public class Login {

        [Required(ErrorMessage ="User" )]
        public string? Username { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string? Password{ get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set;}





    }
}
