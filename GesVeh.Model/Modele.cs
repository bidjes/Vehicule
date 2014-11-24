using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class Modele:BaseModel
    {
        public string Nom { get; set; }
        public Marque Marque { get; set; }
        public IList<Finition> Finitions { get; set; }
    }
}
