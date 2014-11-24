using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesVeh.Model
{
    public interface IModele
    {
        int ID { get; set; }
        string Nom { get; set; }
        IMarque Marque { get; set; }
        IList<IFinition> Finitions { get; set; }
    }
}
