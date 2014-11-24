using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public interface IContrat
    {
        int ID { get; set; }
        Etat Etat { get; set; }
        int Mois { get; set; }
        int Kms { get; set; }
        decimal Loyer { get; set; }
        IVehicule Vehicule { get; set; }
    }
}
