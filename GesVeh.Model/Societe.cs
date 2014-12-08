using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class Societe : BaseModel
    {
        public string Designation { get; set; }
        public virtual IList<Agence> Agences { get; set; }

        public override IEnumerable<ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            foreach (var item in base.Validate(validationContext))
            {
                yield return item;
            }
            
            if (string.IsNullOrWhiteSpace(this.Designation))
            {
                yield return new ValidationResult
                ("La désignation doit-être renseignée.", new[] { "Designation" });
            }
        }
    }
}
