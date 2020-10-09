using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaginasRazorPelis.Models;

namespace PaginasRazorPelis.Data
{
    public class PaginasRazorPelisContext : DbContext
    {
        public PaginasRazorPelisContext (DbContextOptions<PaginasRazorPelisContext> options)
            : base(options)
        {
        }

        public DbSet<PaginasRazorPelis.Models.Pelicula> Pelicula { get; set; }

        public DbSet<PaginasRazorPelis.Models.Nums> Nums { get; set; }
    }
}
