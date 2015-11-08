using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace NettButikk.Model
{
    public class Ordre
    {
        public int ID { get; set; }

        [Display(Name = "Vare")]
        public DateTime Dato { get; set; }

        [Display(Name = "Betalt")]
        public string Betalt { get; set; }

        [Display(Name = "Sendt")]
        public string Sendt { get; set; }
    }
}
