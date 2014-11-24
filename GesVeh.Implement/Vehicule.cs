using GesVeh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesVeh.Implement
{
    public class Vehicule:IVehicule
    {
        public int ID { get; set; }

        public string Immatriculation { get; set; }

        public Etat Etat { get; set; }

        public IFinition Finition { get; set; }

        public IList<IOptions> OptionsSupp { get; set; }

        public IList<IContrat> Contrats { get; set; }

        public IList<IAffectation> Affectations { get; set; }

        public IList<IReparation> Reparations { get; set; }


        public IAffectation GetCurrent()
        {
            return Affectations.Where(y => y.Fin >= DateTime.Now && y.Debut <= DateTime.Now).First();
        }

        public IAffectation GetLast()
        {
            return Affectations.Where(y => y.Fin == Affectations.Max(x => x.Fin)).First();
        }


        IContrat IVehicule.GetCurrent()
        {
            return Contrats.Where(y => y.Debut >= DateTime.Now && y.Debut <= DateTime.Now).First();
        }

        IContrat IVehicule.GetLast()
        {
            return Contrats.Where(y => y.Fin == Contrats.Max(x => x.Fin)).First();
        }

        public IContrat GetLastSameState()
        {
            return Contrats.Where(y => y.Fin == Contrats.Max(x => x.Fin) && y.Etat == this.Etat).First();
        }
    }
}
