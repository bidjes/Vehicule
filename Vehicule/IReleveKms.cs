using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public interface IReleveKms
    {
        int ID { get; set; }
        IVehicule Vehicule { get; set; }
        DateTime DateReleve { get; set; }
        int Kms { get; set; }
    }
}
