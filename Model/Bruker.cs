using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NettButikk.Model
{
    public class Bruker
    {
        [Required(ErrorMessage = "Navn må oppgis")]
        public string Navn { get; set; }
        [Required(ErrorMessage = "Passordmå oppgis")]
        public string Passord { get; set; }   
    }
}
