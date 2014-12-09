using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class Modele:BaseModel
    {
        public Modele()
        {
            
        }
        public string Nom { get; set; }
        public int MarqueID { get; set; }
        public virtual Marque Marque { get; set; }
        public virtual IList<Finition> Finitions { get; set; }

        public override IEnumerable<ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            foreach (var item in base.Validate(validationContext))
            {
                yield return item;
            }
            
            if (string.IsNullOrWhiteSpace(this.Nom))
            {
                yield return new ValidationResult
                ("Il faut un nom pour ce modèle", new[] { "Nom" });
            }
            
            if (this.Marque == null)
            {
                yield return new ValidationResult
                ("Il faut une marque rattachée à ce modèle", new[] { "Marque" });
            }
        }
    }
}
