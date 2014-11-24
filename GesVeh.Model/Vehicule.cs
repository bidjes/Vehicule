using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesVeh.Model
{
    public class Vehicule : BaseModel
    {
        public string Immatriculation { get; set; }

        public Etat Etat { get; set; }

        public Finition Finition { get; set; }

        public IList<Options> OptionsSupp { get; set; }

        public IList<Contrat> Contrats { get; set; }

        public IList<Affectation> Affectations { get; set; }

        public IList<Reparation> Reparations { get; set; }

        public IList<ReleveKms> RelevesKms { get; set; }

        public Affectation GetCurrentAffectation()
        {
            return Affectations.Where(y => y.Fin >= DateTime.Now && y.Debut <= DateTime.Now).First();
        }

        public Affectation GetLastAffectation()
        {
            return Affectations.Where(y => y.Fin == Affectations.Max(x => x.Fin)).First();
        }

        public Contrat GetCurrentContrat()
        {
            return Contrats.Where(y => y.Debut >= DateTime.Now && y.Debut <= DateTime.Now).First();
        }

        public Contrat GetLastContrat()
        {
            return Contrats.Where(y => y.Fin == Contrats.Max(x => x.Fin)).First();
        }

        public Contrat GetLastSameStateContrat()
        {
            return Contrats.Where(y => y.Fin == Contrats.Max(x => x.Fin) && y.Etat == this.Etat).First();
        }

        public ReleveKms GetLastKms()
        {
            return RelevesKms.Where(y => y.DateReleve == RelevesKms.Max(x => x.DateReleve)).First();
        }

        public Marque GetMarque()
        {
            return Finition.Modele.Marque;
        }

        public Modele GetModele()
        {
            return Finition.Modele;
        }

        public IList<Options> GetFullOptions()
        {
            List<Options> mesOptions = new List<Options>();
            mesOptions.AddRange(Finition.Options);
            mesOptions.AddRange(OptionsSupp);
            return mesOptions;
        }

        public Employe GetCurrentEmploye()
        {
            return Affectations.Where(y => y.Fin >= DateTime.Now && y.Debut <= DateTime.Now).First().Employe;
        }
    }

    public enum Etat
    {
        Demande,
        Commande,
        Actif
    }
}