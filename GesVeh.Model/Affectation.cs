using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class Affectation : BaseModel
    {
        public Vehicule Vehicules { get; set; }
        public Agence Agences { get; set; }
        public Employe Employe { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }
    }
}