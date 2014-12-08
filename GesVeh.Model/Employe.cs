using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    /// <summary>
    /// Description simplifiée d'un employé
    /// </summary>
    public class Employe : BaseModel
    {
        public string Matricule { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public virtual IList<Affectation> Affectations { get; set; }

        public override IEnumerable<ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            foreach (var item in base.Validate(validationContext))
            {
                yield return item;
            }

            if (string.IsNullOrWhiteSpace(this.Nom))
            {
                yield return new ValidationResult
                ("Le nom doit-être renseigné", new[] { "Nom" });
            }
            
            if (string.IsNullOrWhiteSpace(this.Prenom))
            {
                yield return new ValidationResult
                ("Le prénom doit-être renseigné", new[] { "Prenom" });
            }
        }
    }
}