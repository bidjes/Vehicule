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

        public DbSet<Vehicule> Vehicules { get; set; }

        
        public DbSet<Marque> Marques { get; set; }
        public DbSet<Modele> Modeles { get; set; }
        public DbSet<Finition> Finitions { get; set; }
        public DbSet<Contrat> Contrats { get; set; }
        public DbSet<Societe> Societes{ get; set; }
        public DbSet<Agence> Agences{ get; set; }
        public DbSet<Reparation> Reparation { get; set; }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<Affectation> Affectations { get; set; }
    }
}