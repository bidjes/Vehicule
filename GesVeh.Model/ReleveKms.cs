using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class ReleveKms : BaseModel
    {
        public int VehiculeID { get; set; }
        public virtual Vehicule Vehicule { get; set; }
        public DateTime DateReleve { get; set; }
        public int Kms { get; set; }

        public override IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
