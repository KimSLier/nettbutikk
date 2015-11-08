using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NettButikk.DAL;
using NettButikk.Model;

namespace NettButikk.BLL
{
    public class OrdrerBLL
    {
        public bool RegistrerOrdre(int prodId) {
            OrdrerDAL ordreDal = new OrdrerDAL();
            return ordreDal.RegistrerOrdre(prodId);
        }

        public bool SendOrdre(int ordreId) {
            OrdrerDAL ordreDal = new OrdrerDAL();
            return ordreDal.SendOrdre(ordreId);
        }

        public List<Ordre> AlleOrdre() {
            OrdrerDAL ordreDal = new OrdrerDAL();
            return ordreDal.AlleOrdre();
        }
    }
}
