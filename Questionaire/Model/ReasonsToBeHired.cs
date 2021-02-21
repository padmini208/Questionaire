using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Questionaire.Model
{
    public class ReasonsToBeHired
    {
        [Key]
        public int ID { get; set; } 

        [Required]
        public string FirstName { get; set; }

        [Required]
         public string LastName { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Name cannot be greater than 500")]
        public string FirstReason { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Name cannot be greater than 500")]
        public string SecondReason { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Name cannot be greater than 500")]
        public string ThirdReason { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [Display(Name = "Email address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email{ get; set; }

        public DateTime LastUpdated { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
