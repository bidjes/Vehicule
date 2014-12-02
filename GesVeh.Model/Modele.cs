using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class Modele:BaseModel
    {
        public string Nom { get; set; }
        public int MarqueID { get; set; }
        public virtual Marque Marque { get; set; }
        public virtual IList<Finition> Finitions { get; set; }
    }
}
