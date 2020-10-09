using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PaginasRazorPelis.Data;
using System;
using System.Linq;

namespace PaginasRazorPelis.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PaginasRazorPelisContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PaginasRazorPelisContext>>()))
            {
                // Look for any Peliculas.
                if (context.Pelicula.Any())
                {
                    return;   // DB has been seeded
                }

                context.Pelicula.AddRange(
                    new Pelicula
                    {
                        Titulo = "When Harry Met Sally",
                        FechaEstreno = DateTime.Parse("1989-2-12"),
                        Genero = "Romantic Comedy",
                        Precio = 7.99M,
                        Rating = "R"

                    },

                    new Pelicula
                    {
                        Titulo = "Ghostbusters ",
                        FechaEstreno = DateTime.Parse("1984-3-13"),
                        Genero = "Comedy",
                        Precio = 8.99M,
                        Rating = "R"
                    },

                    new Pelicula
                    {
                        Titulo = "Ghostbusters 2",
                        FechaEstreno = DateTime.Parse("1986-2-23"),
                        Genero = "Comedy",
                        Precio = 9.99M,
                        Rating = "R"
                    },

                    new Pelicula
                    {
                        Titulo = "Rio Bravo",
                        FechaEstreno = DateTime.Parse("1959-4-15"),
                        Genero = "Western",
                        Precio = 3.99M,
                        Rating = "R"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}