using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebImoveis.Domain.Entities;

namespace WebImoveis.WebApp.Pages.Properties
{
    public class PropertyDeleteModel : PageModel
    {
        private readonly WebImoveis.Data.Contexts.ApplicationDbContext _context;

        public PropertyDeleteModel(WebImoveis.Data.Contexts.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Property Property { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Property = await _context.Properties
                .Include(a => a.Address).FirstOrDefaultAsync(m => m.PropertyId == id);

            if (Property == null)
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

            Property = await _context.Properties.FindAsync(id);

            if (Property != null)
            {
                _context.Properties.Remove(Property);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./PropertyList");
        }
    }
}
