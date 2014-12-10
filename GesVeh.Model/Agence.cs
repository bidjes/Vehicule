using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public override IEnumerable<ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            foreach (var item in base.Validate(validationContext))
            {
                yield return item;
            }
            if (this.Designation == null)
            {
                yield return new ValidationResult
                ("Il faut une désignation.", new[] { "Designation" });
            }
            if (this.SocieteID < 1)
            {
                yield return new ValidationResult
                ("Il faut une Société reliée à cette Agence.", new[] { "Societe","SocieteID" });
            }
        }
    }
}