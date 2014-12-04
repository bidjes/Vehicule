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

        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
}
