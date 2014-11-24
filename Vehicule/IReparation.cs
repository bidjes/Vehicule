using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public interface IReparation
    {
        int ID { get; set; }
        IVehicule Vehicule { get; set; }
    }
}
