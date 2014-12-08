using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    /// <summary>
    /// description simplifié d'une affectation
    /// </summary>
    public class Affectation : BaseModel
    {
        public int VehiculeID { get; set; }
        public virtual Vehicule Vehicule { get; set; }
        public int AgenceID { get; set; }
        public virtual Agence Agence { get; set; }
        public int EmployeID { get; set; }
        public virtual Employe Employe { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }

        public override IEnumerable<ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            foreach (var item in base.Validate(validationContext))
            {
                yield return item;
            }
            if (this.Vehicule == null)
            {
                yield return new ValidationResult
                ("Il faut un véhicule relié à cette affectation.", new[] { "Vehicule" });
            }
            if (this.Agence == null)
            {
                yield return new ValidationResult
                ("Il faut une Agence relié à cette affectation.", new[] { "Agence" });
            }
            if (this.Employe == null)
            {
                yield return new ValidationResult
                ("Il faut un employé relié à cette affectation.", new[] { "Employe" });
            }
            if (this.Debut < this.Fin)
            {
                yield return new ValidationResult
                ("La date de début ne doit pas être supérieure à la date de fin.", new[] { "Debut","Fin" });
            }
        }
    }
}