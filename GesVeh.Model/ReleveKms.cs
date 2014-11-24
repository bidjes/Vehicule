using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class ReleveKms : BaseModel
    {
        public Vehicule Vehicule { get; set; }
        public DateTime DateReleve { get; set; }
        public int Kms { get; set; }
    }
}
