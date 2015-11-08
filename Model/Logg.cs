using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NettButikk.Model
{
    public class LoggModel
    {
        [Display(Name = "Tidspunkt")]
        public DateTime Tidspunkt { get; set; }
        [Display(Name = "Bruker")]
        public string Bruker { get; set; }
        [Display(Name = "Handling")]
        public string Handling { get; set; }
    }
}
