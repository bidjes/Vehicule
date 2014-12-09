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
        //IList<Reparation> repa, IList<Options> opts, IList<Affectation> affec,IList<ReleveKms> releve,IList<Contrat> cont
        public Vehicule(Finition fini)
        {
            //this.Reparations = repa;
            //this.OptionsSupp = opts;
            //this.Affectations = affec;
            //this.RelevesKms = releve;
            //this.Contrats = cont;

            this.Finition = fini;
            this.Etat = Etat.Demande;
            this.Reparations = new List<Reparation>();
            this.OptionsSupp = new List<Options>();
            this.Affectations = new List<Affectation>();
            this.RelevesKms = new List<ReleveKms>();
            this.Contrats = new List<Contrat>();
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
            //model de base
            foreach (var item in base.Validate(validationContext))
            {
                yield return item;
            }
            //finition
            if (this.Finition == null)
            {
                yield return new ValidationResult
                ("Il faut une finition pour le véhicule", new[] { "Finition" });
            }
            //Contrats
            if (this.Proprietaire == false)
            {
                if (this.Contrats.Count == 0)
                {
                    yield return new ValidationResult
                    ("Le véhicule n'est pas acheté, mais n'a aucun contrat.", new[] { "Proprietaire", "Contrats" });
                }
                else
                {
                    if (this.Contrats.Min(y => y.Debut) != this.Entree)
                    {
                        yield return new ValidationResult
                        ("La date d'entrée du véhicule ne correspond pas à la date de début du premier contrat.", new[] { "Contrats", "Entree" });
                    }
                    if (this.Contrats.Max(y => y.Fin) > this.Sortie)
                    {
                        yield return new ValidationResult
                        ("La date de fin du dernier contrat ne peut pas être supérieure à la date de sortie du véhicule", new[] { "Contrats", "Entree" });
                    }
                }
            }
            //Affectations
            if (this.Affectations.Count == 0)
            {
                yield return new ValidationResult 
                ("Il faut au moins une affectation.", new[] { "Affectations"});
            }
            else
            {
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
            }
            //Affectations et contrats
            if (this.Proprietaire == false && this.Affectations.Count > 0 && this.Contrats.Count > 0)
            {
                if (this.Affectations.Min(y => y.Debut) != this.Contrats.Min(y => y.Debut))
                {
                    yield return new ValidationResult
                    ("La date du premier contrat doit démarrer à la date de la première affectation.", new[] { "Affectations", "Entree" });
                }
            }
        }
        public override void InitCreate()
        {
            base.InitCreate();
            Contrats.Add(new Contrat(this));
            Contrats.First().InitCreate();
        }
    }

    public enum Etat
    {
        Demande,
        Commande,
        Actif
    }
}