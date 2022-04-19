using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebImoveis.Data.Contexts;
using WebImoveis.Domain.Entities;

namespace WebImoveis.Telas.Pages.Propriedades
{
    public class DetailsModel : PageModel
    {
        private readonly WebImoveis.Data.Contexts.ApplicationDbContext _context;

        public DetailsModel(WebImoveis.Data.Contexts.ApplicationDbContext context)
        {
            _context = context;
        }

        public Address Address { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Address = await _context.Addresses.FirstOrDefaultAsync(m => m.AddressId == id);

            if (Address == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
