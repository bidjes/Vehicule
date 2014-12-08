using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class Marque : BaseModel
    {
        public string Nom { get; set; }
        public virtual IList<Modele> Modeles { get; set; }

        public override IEnumerable<ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            foreach (var item in base.Validate(validationContext))
            {
                yield return item;
            }
            
            if (string.IsNullOrWhiteSpace(this.Nom))
            {
                yield return new ValidationResult
                ("Il faut un nom pour cette marque", new[] { "Nom" });
            }
        }
    }
}
