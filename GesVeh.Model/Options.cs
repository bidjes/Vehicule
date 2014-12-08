using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class Options : BaseModel
    {
        public string Description { get; set; }
        public decimal Prix { get; set; }

        public override IEnumerable<ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            foreach (var item in base.Validate(validationContext))
            {
                yield return item;
            }
            
            if (string.IsNullOrWhiteSpace(this.Description))
            {
                yield return new ValidationResult
                ("Il faut une description pour cette option", new[] { "Description" });
            }
            
            if (this.Prix < 0m )
            {
                yield return new ValidationResult
                ("Il faut un prix pour cette option.", new[] { "Prix" });
            }
        }
    }
}
