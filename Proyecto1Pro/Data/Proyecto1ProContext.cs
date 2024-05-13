using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto1Pro.Models;

namespace Proyecto1Pro.Data
{
    public class Proyecto1ProContext : DbContext
    {
        public Proyecto1ProContext (DbContextOptions<Proyecto1ProContext> options)
            : base(options)
        {
        }

        public DbSet<Proyecto1Pro.Models.Usuario> Usuario { get; set; } = default!;
        public DbSet<Proyecto1Pro.Models.Peluche> Peluche { get; set; } = default!;
        public DbSet<Proyecto1Pro.Models.Catalogo> Catalogo { get; set; } = default!;
        public DbSet<Proyecto1Pro.Models.Compra> Compra { get; set; } = default!;
    }
}
