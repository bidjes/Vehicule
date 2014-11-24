using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class Reparation : BaseModel
    {
        public decimal Cout { get; set; }
        public Vehicule Vehicule { get; set; }
    }
}
