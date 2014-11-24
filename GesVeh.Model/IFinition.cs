using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public interface IFinition
    {
        int ID { get; set; }
        string Nom { get; set; }
        IModele Modele { get; set; }
        IList<IOptions> Options { get; set; }
    }
}
