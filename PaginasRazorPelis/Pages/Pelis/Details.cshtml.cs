using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PaginasRazorPelis.Data;
using PaginasRazorPelis.Models;

namespace PaginasRazorPelis.Pages.Pelis
{
    public class DetailsModel : PageModel
    {
        private readonly PaginasRazorPelis.Data.PaginasRazorPelisContext _context;

        public DetailsModel(PaginasRazorPelis.Data.PaginasRazorPelisContext context)
        {
            _context = context;
        }

        public Pelicula Pelicula { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pelicula = await _context.Pelicula.FirstOrDefaultAsync(m => m.ID == id);

            if (Pelicula == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
