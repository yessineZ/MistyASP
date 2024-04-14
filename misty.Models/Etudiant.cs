using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace misty.Models
{
    public class Etudiant
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }




        [Required]
        [DisplayName("Age")]
        public int Age { get; set; }





    }
}
