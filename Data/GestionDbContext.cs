using Microsoft.EntityFrameworkCore;
using Projet_DotNet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Projet_DotNet.Data
{
    public class GestionDbContext : IdentityDbContext
    {

        public GestionDbContext(DbContextOptions<GestionDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Employe>().ToTable("Employes", "HR"). cette ligne est équivalente à [Table("Employes", Schema = "HR")]
        }

        public DbSet<Departement> Departements { get; set; }
        public DbSet<Employe> Employes { get; set; }

    }
}



//using Microsoft.EntityFrameworkCore;
//using Projet_DotNet.Models;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

//namespace Projet_DotNet.Data
//{
//    public class GestionDbContext :DbContext 
//    {

//        public GestionDbContext(DbContextOptions<GestionDbContext> options) : base(options)
//        {
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);
//            //modelBuilder.Entity<Employe>().ToTable("Employes", "HR"). cette ligne est équivalente à [Table("Employes", Schema = "HR")]
//        }

//        public DbSet<Departement> Departements { get; set; }
//        public DbSet<Employe> Employes { get; set; }

//    }
//}
