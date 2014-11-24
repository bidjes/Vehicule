using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class Contrat : BaseModel
    {
        public Etat Etat { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }
        public int Mois { get; set; }
        public int Kms { get; set; }
        public decimal Loyer { get; set; }
        public Vehicule Vehicule { get; set; }
    }
}
