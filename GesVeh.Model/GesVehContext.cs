using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GesVeh.Model
{
    public class GesVehContext:DbContext
    {

        public System.Data.Entity.DbSet<GesVeh.Model.Vehicule> Vehicules { get; set; }

        public System.Data.Entity.DbSet<GesVeh.Model.Finition> Finitions { get; set; }
    }
}