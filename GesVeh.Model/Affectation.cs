using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    /// <summary>
    /// description simplifié d'une affectation
    /// </summary>
    public class Affectation : BaseModel
    {
        public int VehiculeID { get; set; }
        public virtual Vehicule Vehicule { get; set; }
        public int AgenceID { get; set; }
        public virtual Agence Agence { get; set; }
        public int EmployeID { get; set; }
        public virtual Employe Employe { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }
    }
}