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
    public class IndexModel : PageModel
    {
        private readonly WebImoveis.Data.Contexts.ApplicationDbContext _context;

        public IndexModel(WebImoveis.Data.Contexts.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Address> Address { get;set; }

        public async Task OnGetAsync()
        {
            Address = await _context.Addresses.ToListAsync();
        }
    }
}
