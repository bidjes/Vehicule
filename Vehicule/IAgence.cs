using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public interface IAgence
    {
        int ID { get; set; }
        ISociete Societe { get; set; }
        IList<IAffectation> Affectations { get; set; }
    }
}
