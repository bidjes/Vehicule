using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesVeh.Model
{
    public interface IVehicule
    {
        int ID { get; set; }
        string Immatriculation { get; set; }
        IList<IContrat> Contrats { get; set; }
        IList<IAffectation> Affectations { get; set; }
        IList<IReparation> Reparations { get; set; }
    }
}