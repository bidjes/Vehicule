using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public interface IEmploye
    {
        int ID { get; set; }
        string Matricule { get; set; }
        string Nom { get; set; }
        string Prenom { get; set; }
        IList<IAffectation> Affectations { get; set; }
    }
}
