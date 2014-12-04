using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class Options : BaseModel
    {
        public int Description { get; set; }
        public decimal Prix { get; set; }

        public override IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
