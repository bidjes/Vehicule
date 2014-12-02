using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public class Societe : BaseModel
    {
        public string Designation { get; set; }
        public virtual IList<Agence> Agences { get; set; }
    }
}
