using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public interface ISociete
    {
        int ID { get; set; }
        string Designation { get; set; }
        IList<IAgence> Agences { get; set; }
    }
}
