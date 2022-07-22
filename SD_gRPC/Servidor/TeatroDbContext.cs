using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Servidor
{
    public class TeatroDbContext : DbContext
    {
        public TeatroDbContext(DbContextOptions<TeatroDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cliente>().HasMany(e => e.Bilhetes);
        }

        public DbSet<Cliente> Clients { get; set; }
        public DbSet<Bilhete> Bilhets { get; set; }
        public DbSet<Espetaculo> Espetaculs { get; set; }
        public DbSet<Sessao> Sessas { get; set; }
        public DbSet<Teatro> Teatrs { get; set; }
        public DbSet<Recibo> Recibos { get; set; }
    }
}
