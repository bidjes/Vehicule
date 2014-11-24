using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class Marque : BaseModel
    {
        public string Nom { get; set; }
        public IList<Modele> Modeles { get; set; }
    }
}
