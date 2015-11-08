using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NettButikk.Model
{
    public class BrukerInfo
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Fornavn må oppgis")]
        [Display(Name = "Fornavn")]
        public string Fornavn { get; set; }

        [Required(ErrorMessage = "Etternavn må oppgis")]
        [Display(Name = "Etternavn")]
        public string Etternavn { get; set; }

        [Required(ErrorMessage = "Adresse må oppgis")]
        [Display(Name = "Adresse")]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "Postnr må oppgis")]
        [Display(Name = "Postnr")]
        public string Postnr { get; set; }

        [Required(ErrorMessage = "Epost må oppgis")]
        [Display(Name = "Epost")]
        public string Epost { get; set; }

        [Display(Name = "Brukernavn")]
        public string Brukernavn { get; set; }
    }
}
