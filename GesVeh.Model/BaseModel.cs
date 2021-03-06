﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesVeh.Model
{
    /// <summary>
    /// Classe de base avec infos pour insertion en DB
    /// </summary>
    public abstract class BaseModel : IValidatableObject
    {
        public BaseModel()
        {
            this.Delete = false;
            this.CreateBy = "Colas";
            this.CreationDate = DateTime.Now;
            this.ModificationDate = null;
            this.DeletationDate = null;
            this.ModifiedBy = null;
            this.DeleteBy = null;
        }
        public int ID { get; set; }
        public string CreateBy { get; set; }
        public string ModifiedBy { get; set; }
        public string DeleteBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public DateTime? DeletationDate { get; set; }
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
            if (this.CreationDate < DateTime.Now)
            {
                
                if (this.ModificationDate == null)
                {
                    yield return new ValidationResult
                    ("Il faut renseigner une date de modification.", new[] { "ModificationDate" });
                }
                
                if (string.IsNullOrWhiteSpace(this.ModifiedBy))
                {
                    yield return new ValidationResult
                    ("Il faut renseigner un modificateur.", new[] { "ModifiedBy" });
                }
            }
            if (this.Delete)
            {
                if ( string.IsNullOrEmpty(this.DeleteBy))
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

        public virtual void InitCreate()
        {
            
        }
        public virtual void InitModify()
        {
            this.ModifiedBy = "nvardalas";
            this.ModificationDate = DateTime.Now;
        }
    }
}