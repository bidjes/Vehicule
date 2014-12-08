using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class Reparation : BaseModel
    {
        public decimal Cout { get; set; }
        public int VehiculeID { get; set; }
        public virtual Vehicule Vehicule { get; set; }

        public override IEnumerable<ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            foreach (var item in base.Validate(validationContext))
            {
                yield return item;
            }
            
            if (this.Cout < 0)
            {
                yield return new ValidationResult
                ("Le cout doit-être supérieur à 0", new[] { "Cout" });
            }
            
            if (this.Vehicule == null)
            {
                yield return new ValidationResult
                ("Il faut un véhicule relié à cette réparation", new[] { "Vehicule" });
            }
        }
    }
}
