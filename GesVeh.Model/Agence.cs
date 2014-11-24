using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class Agence : BaseModel
    {
        public string Designation { get; set; }
        public Societe Societe { get; set; }
        public IList<Affectation> Affectations { get; set; }
    }
}
