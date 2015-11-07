using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace NettButikk.Model
{
    public class Produkt
    {
        public int id { get; set; }

        [Display(Name = "Vare")]
        public string navn { get; set; }

        [Display(Name = "Pris")]
        public int pris { get; set; }
    }
}
