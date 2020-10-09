using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaginasRazorPelis.Data;
using PaginasRazorPelis.Models;

namespace PaginasRazorPelis.Pages.Pelis
{
    public class IndexModel : PageModel
    {
        private readonly PaginasRazorPelis.Data.PaginasRazorPelisContext _context;

        public IndexModel(PaginasRazorPelis.Data.PaginasRazorPelisContext context)
        {
            _context = context;
        }

        public IList<Pelicula> Pelicula { get;set; }

        [BindProperty(SupportsGet = true)]
        public string CadenaBusqueda { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Generos { get; set; }

        [BindProperty(SupportsGet = true)]
        public string GeneroPelicula { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> consultaGenero = from m in _context.Pelicula
                                                orderby m.Genero
                                                select m.Genero;

            var pelis = from m in _context.Pelicula select m ;

            if (! string.IsNullOrEmpty(CadenaBusqueda) )//(! CadenaBusqueda = null or CadenaBusqueda="")
            {
                pelis = pelis.Where(s => s.Titulo.Contains(CadenaBusqueda));
            }
            if (!string.IsNullOrEmpty(GeneroPelicula))
            {
                pelis = pelis.Where(s => s.Genero == GeneroPelicula);
            }

            Generos = new SelectList(await consultaGenero.Distinct().ToListAsync());
            Pelicula = await pelis.ToListAsync();
        }
    }
}
