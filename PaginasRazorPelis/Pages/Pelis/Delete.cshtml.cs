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
    public class DeleteModel : PageModel
    {
        private readonly PaginasRazorPelis.Data.PaginasRazorPelisContext _context;

        public DeleteModel(PaginasRazorPelis.Data.PaginasRazorPelisContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pelicula = await _context.Pelicula.FindAsync(id);

            if (Pelicula != null)
            {
                _context.Pelicula.Remove(Pelicula);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
