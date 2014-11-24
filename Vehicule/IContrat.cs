using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public interface IContrat
    {
        int ID { get; set; }
        IVehicule Vehicule { get; set; }
    }
}
