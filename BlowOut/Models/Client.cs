using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        public int ClientID { get; set; }

        [Required(ErrorMessage = "Please enter Client First Name!")]
        [Display(Name = "Client First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Client Last Name!")]
        [Display(Name = " Client Last Name")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Please enter Client Address!")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter Client City!")]
        [Display(Name = " City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter Client State!")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter Client Zip!")]
        [Display(Name = "Zip Code")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Zip should be 5 digits")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter Client Email!")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Client Phone!")]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^(\()\d{3}(\))(\s)\d{3}(-)\d{4}$", ErrorMessage ="Phone number should be in the format (xxx) xxx-xxxx")]
        public string Phone { get; set; }
    }
}