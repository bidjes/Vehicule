using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class Marque
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public IList<Modele> Modeles { get; set; }
    }
}
