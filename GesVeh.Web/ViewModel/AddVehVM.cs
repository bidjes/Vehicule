using GesVeh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesVeh.Web.ViewModel
{
    public class AddVehVM
    {
        public int FinitionID { get; set; }
        public int AgenceID { get; set; }
        public int EmployeID { get; set; }
        public Etat Etat { get; set; }
        public bool Proprietaire { get; set; }
        public DateTime Entree { get; set; }
        public DateTime Sortie { get; set; }
        public int Kms { get; set; }
        public int Mois { get; set; }
    }
}