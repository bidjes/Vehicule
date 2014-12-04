using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class Finition : BaseModel
    {
        public string Nom { get; set; }
        public decimal Prix { get; set; }
        public Modele Modele { get; set; }
        public IList<Options> Options { get; set; }

        public override IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}