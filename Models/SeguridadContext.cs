using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SeguridadContext: DbContext
    {
        public SeguridadContext(DbContextOptions<SeguridadContext>options)
            :base(options)
        {

        }

        public DbSet<Permisos> Permisos { get; set; }
        public DbSet<TipoPermisos> TipoPermisos { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permisos>().ToTable("Permisos");
            modelBuilder.Entity<TipoPermisos>().ToTable("TipoPermisos");
        }
    }
}
