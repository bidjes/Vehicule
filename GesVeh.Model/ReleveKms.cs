using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class ReleveKms : BaseModel
    {
        public int VehiculeID { get; set; }
        public virtual Vehicule Vehicule { get; set; }
        public DateTime DateReleve { get; set; }
        public int Kms { get; set; }

        public override IEnumerable<ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            foreach (var item in base.Validate(validationContext))
            {
                yield return item;
            }
            
            if (this.Vehicule == null)
            {
                yield return new ValidationResult
                ("Il faut un véhicule relié à ce relevé kilométrique", new[] { "Vehicule" });
            }
            
            if (this.DateReleve.Year < 2000)
            {
                yield return new ValidationResult
                ("La date du relevé n'est pas pertinente", new[] { "DateReleve" });
            }
            
            if (this.Kms < 0)
            {
                yield return new ValidationResult
                ("La nombre de kms relevés n'est pas pertinent", new[] { "Kms" });
            }
        }
    }
}
