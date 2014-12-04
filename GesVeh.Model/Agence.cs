using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    /// <summary>
    /// Description simplifiée d'une agence
    /// </summary>
    public class Agence : BaseModel
    {
        public string Designation { get; set; }
        public int SocieteID { get; set; }
        public virtual Societe Societe { get; set; }
        public IList<Affectation> Affectations { get; set; }

        public override IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
