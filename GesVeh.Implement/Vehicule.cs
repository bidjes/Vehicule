using GesVeh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesVeh.Implement
{
    public class Vehicule:IVehicule
    {
        public int ID { get; set; }

        public string Immatriculation { get; set; }

        public Etat Etat { get; set; }

        public IFinition Finition { get; set; }

        public IList<IOptions> OptionsSupp { get; set; }

        public IList<IContrat> Contrats { get; set; }

        public IList<IAffectation> Affectations { get; set; }

        public IList<IReparation> Reparations { get; set; }

        public IList<IReleveKms> RelevesKms { get; set; }

        public IAffectation GetCurrentAffectation()
        {
            return Affectations.Where(y => y.Fin >= DateTime.Now && y.Debut <= DateTime.Now).First();
        }

        public IAffectation GetLastAffectation()
        {
            return Affectations.Where(y => y.Fin == Affectations.Max(x => x.Fin)).First();
        }

        public IContrat GetCurrentContrat()
        {
            return Contrats.Where(y => y.Debut >= DateTime.Now && y.Debut <= DateTime.Now).First();
        }

        public IContrat GetLastContrat()
        {
            return Contrats.Where(y => y.Fin == Contrats.Max(x => x.Fin)).First();
        }

        public IContrat GetLastSameStateContrat()
        {
            return Contrats.Where(y => y.Fin == Contrats.Max(x => x.Fin) && y.Etat == this.Etat).First();
        }

        public IReleveKms GetLastKms()
        {
            return RelevesKms.Where(y => y.DateReleve == RelevesKms.Max(x => x.DateReleve)).First();
        }

        public IMarque GetMarque()
        {
            return Finition.Modele.Marque;
        }

        public IModele GetModele()
        {
            return Finition.Modele;
        }

        public IList<IOptions> GetFullOptions()
        {
            List<IOptions> mesOptions = new List<IOptions>();
            mesOptions.AddRange(Finition.Options);
            mesOptions.AddRange(OptionsSupp);
            return mesOptions;
        }

        public IEmploye GetCurrentEmploye()
        {
            return Affectations.Where(y => y.Fin >= DateTime.Now && y.Debut <= DateTime.Now).First().Employe;
        }
    }
}
