using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    public class ClientInstuments
    {
        public Client clients { get; set; }
        public Instrument instruments { get; set; }
    }
}