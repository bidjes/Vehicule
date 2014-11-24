using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public interface IAffectation
    {
        int ID { get; set; }
        IVehicule Vehicules { get; set; }
        IAgence Agences { get; set; }
        IEmploye Employe { get; set; }
        DateTime Debut { get; set; }
        DateTime Fin { get; set; }
    }
}