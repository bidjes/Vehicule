using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesVeh.Model
{
    public class Vehicule : BaseModel 
    {
        public Vehicule(IList<Reparation> repa, IList<Options> opts, IList<Affectation> affec,IList<ReleveKms> releve,IList<Contrat> cont)
        {
            this.Reparations = repa;
            this.OptionsSupp = opts;
            this.Affectations = affec;
            this.RelevesKms = releve;
            this.Contrats = cont;
        }
        public string Immatriculation { get; set; }

        public Etat Etat { get; set; }

        public int FinitionID { get; set; }
        public virtual Finition Finition { get; set; }
        public bool Proprietaire { get; set; }
        public DateTime Entree { get; set; }
        public DateTime Sortie { get; set; }

        public virtual IList<Options> OptionsSupp { get; set; }

        public virtual IList<Contrat> Contrats { get; set; }

        public virtual IList<Affectation> Affectations { get; set; }

        public virtual IList<Reparation> Reparations { get; set; }

        public virtual IList<ReleveKms> RelevesKms { get; set; }

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
            return this.GetCurrentAffectation().Employe;
        }

        /// <summary>
        /// Permet de s'assurer que l'objet est conforme à nos règles
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns>Liste de règles violées</returns>
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext) 
        {
            if (this.Proprietaire == false && this.Contrats.Count == 0) 
            { 
                yield return new ValidationResult 
                ("Le véhicule n'est pas acheté, mais n'a aucun contrat.", new[] { "Proprietaire","Contrats"}); 
            }
            if (this.Affectations.Min(y => y.Debut) != this.Entree)
            {
                yield return new ValidationResult
                ("La date d'entrée du véhicule ne correspond pas à la date de début de la première affectation.", new[] { "Affectations", "Entree" });
            }
            if (this.Affectations.Max(y => y.Fin) > this.Sortie)
            {
                yield return new ValidationResult
                ("La dernière affectation ne peut pas être supérieure à la date de sortie du véhicule.", new[] { "Affectations", "Sortie" });
            }
            if (this.Proprietaire == false && this.Contrats.Min(y => y.Debut) != this.Entree)
            {
                yield return new ValidationResult
                ("La date d'entrée du véhicule ne correspond pas à la date de début du premier contrat.", new[] { "Affectations", "Entree" });
            }
            if (this.Proprietaire == false && this.Contrats.Max(y => y.Fin) > this.Sortie)
            {
                yield return new ValidationResult
                ("La date de fin du dernier contrat ne peut pas être supérieure à la date de sortie du véhicule", new[] { "Affectations", "Entree" });
            }
            
        } 
    }

    public enum Etat
    {
        Demande,
        Commande,
        Actif
    }
}