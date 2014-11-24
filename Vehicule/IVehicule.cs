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
        Etat Etat { get; set; }
        IFinition Finition { get; set; }
        IList<IOptions> OptionsSupp { get; set; }
        IList<IContrat> Contrats { get; set; }
        IList<IAffectation> Affectations { get; set; }
        IList<IReparation> Reparations { get; set; }
    }

    public enum Etat
    {
        Demande,
        Commande,
        Actif
    }
}