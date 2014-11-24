using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class Societe
    {
        public int ID { get; set; }
        public string Designation { get; set; }
        public IList<Agence> Agences { get; set; }
    }
}
