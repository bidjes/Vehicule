using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesVeh.Model
{
    public abstract class BaseModel : IValidatableObject
    {
        public BaseModel()
        {
            this.Delete = false;
        }
        public int ID { get; set; }
        public string CreateBy { get; set; }
        public string ModifiedBy { get; set; }
        public string DeleteBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public DateTime DeletationDate { get; set; }
        public bool Delete { get; set; }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(this.CreateBy))
            {
                yield return new ValidationResult
                ("Il faut renseigner un créateur.", new[] { "CreateBy" });
            }
            if (this.CreationDate == null)
            {
                yield return new ValidationResult
                ("Il faut renseigner une date de création.", new[] { "CreationDate" });
            }
            if (this.Delete)
            {
                if (string.IsNullOrEmpty(this.DeleteBy))
                {
                    yield return new ValidationResult
                    ("Il faut renseigner un suppresseur.", new[] { "DeleteBy" });
                }
                if (this.DeletationDate == null)
                {
                    yield return new ValidationResult
                    ("Il faut renseigner une date de suppression.", new[] { "DeletationDate" });
                }
            }
        }
    }
}