using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebImoveis.Data.Contexts;
using WebImoveis.Domain.Entities;

namespace WebImoveis.WebApp.Pages.Teste
{
    public class DetailsModel : PageModel
    {
        private readonly WebImoveis.Data.Contexts.ApplicationDbContext _context;

        public DetailsModel(WebImoveis.Data.Contexts.ApplicationDbContext context)
        {
            _context = context;
        }

        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.Users.FirstOrDefaultAsync(m => m.UserId == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
