using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class Agence
    {
        public int ID { get; set; }
        public string Designation { get; set; }
        public Societe Societe { get; set; }
        public IList<Affectation> Affectations { get; set; }
    }
}
