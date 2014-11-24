using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public interface IMarque
    {
        int ID { get; set; }
        string Nom { get; set; }
        IList<IModele> Modeles { get; set; }
    }
}
