using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PaginasRazorPelis.Data;
using PaginasRazorPelis.Models;


namespace PaginasRazorPelis.Pages.Pelis
{
    public class Sumador
    {
        public int resultado { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string operador { get; set; }

        public void cal()
        {
            if (operador[0] == '+')
            resultado = x + y;
            else if (operador[0] == '-')
                resultado = x - y;
             else if (operador[0] == '*')
                resultado = x * y;
            else if (operador[0] == '/')
                resultado = x / y;
        }
    }
    public class SumaModel : PageModel
    {
        [BindProperty]
        public Sumador Sumador { get; set; }

        public async  Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Sumador.cal();
            return Page();
        }

    }

}
