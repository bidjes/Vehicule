using GesVeh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesVeh.BLL
{
    public class VehiculeBLL
    {
        public Vehicule InitVeh(Vehicule veh)
        {
            veh.CreateBy = "Colas";
            veh.CreationDate = DateTime.Now;

            if (veh.Proprietaire == false)
            {
                veh.Contrats.Add(new Contrat() { Vehicule = veh, CreateBy = "Colas", CreationDate = DateTime.Now, Debut = veh.Entree, Fin = veh.Sortie, Etat = veh.Etat });
            }
            return veh;
        }
    }
}