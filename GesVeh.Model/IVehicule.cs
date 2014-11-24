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
        IList<IReleveKms> RelevesKms { get; set; }

        IAffectation GetCurrentAffectation();
        IAffectation GetLastAffectation();

        IContrat GetCurrentContrat();
        IContrat GetLastContrat();
        IContrat GetLastSameStateContrat();

        IReleveKms GetLastKms();

        IMarque GetMarque();
        IModele GetModele();

        IOptions GetFullOptions();

        IEmploye GetCurrentEmploye();
    }

    public enum Etat
    {
        Demande,
        Commande,
        Actif
    }
}