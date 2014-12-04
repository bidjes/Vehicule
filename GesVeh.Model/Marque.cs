using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class Marque : BaseModel
    {
        public string Nom { get; set; }
        public virtual IList<Modele> Modeles { get; set; }

        public override IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
