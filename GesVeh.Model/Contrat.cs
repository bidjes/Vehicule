using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class Contrat : BaseModel
    {
        public Etat Etat { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }
        public int Mois { get; set; }
        public int Kms { get; set; }
        public decimal Loyer { get; set; }
        public int VehiculeID { get; set; }
        public virtual Vehicule Vehicule { get; set; }

        public override IEnumerable<ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            foreach (var item in base.Validate(validationContext))
            {
                yield return item;
            }
            
            if (this.Etat > Vehicule.Etat)
            {
                yield return new ValidationResult
                ("L'état du contrat Ne peut pas être supérieur à l'état du véhicule.", new[] { "Vehicule","Etat" });
            }
            
            if (this.Debut > this.Fin)
            {
                yield return new ValidationResult
                ("La date de fin ne peut pas précéder la date de début", new[] { "Debut","Fin" });
            }
            
            
            if (this.Etat > Etat.Demande)
            {
                if (this.Loyer < 1)
                {
                    yield return new ValidationResult
                    ("Le loyer doit-être supérieur ou égal à 1", new[] { "Loyer" });
                }
                if (this.Mois < 1)
                {
                    yield return new ValidationResult
                    ("Le nombre de mois du contrat doit-être supérieur ou égal à 1", new[] { "Mois" });
                }

                if (this.Kms < 1)
                {
                    yield return new ValidationResult
                    ("Le nombre de Kms doit-être supérieur ou égal à 1", new[] { "Kms" });
                }
            }
            
        }
    }
}
