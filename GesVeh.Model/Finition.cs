using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class Finition : BaseModel
    {
        public Finition()
        {
            
        }
        public string Nom { get; set; }
        public decimal Prix { get; set; }
        public Modele Modele { get; set; }
        public IList<Options> Options { get; set; }
        public IList<Vehicule> Vehicules { get; set; }
        public override IEnumerable<ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            foreach (var item in base.Validate(validationContext))
            {
                yield return item;
            }
            
            if (this.Modele == null)
            {
                yield return new ValidationResult
                ("Il faut un modèle de véhicule relié à cette finition.", new[] { "Modele" });
            }
            if (this.Prix < 0m)
            {
                yield return new ValidationResult
                ("Il faut un prix pour cette finition (0€ est accepté).", new[] { "Prix" });
            }
            
            if (string.IsNullOrWhiteSpace(this.Nom))
            {
                yield return new ValidationResult
                ("Il faut un nom pour cette finition", new[] { "Nom" });
            }
        }
    }
}