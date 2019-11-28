using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    [Table("Instrument")]
    public class Instrument
    {
        [Key]
        public int InstrumentID { get; set; }

        [Required (ErrorMessage =  "Please enter Instrument Name!")]
        [Display(Name ="Instrument Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Instrument Type!")]
        [Display(Name = "Instrument Type")]
        public string Type { get; set; }
   
        public string ImageString { get; set; }

        [Required(ErrorMessage = "Please enter Instrument Price!")]
        [Display(Name = "Instrument Price")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Please enter ClientID!")]
        [Display(Name = "Client ID")]
        public int ClientID { get; set; }
    }
}