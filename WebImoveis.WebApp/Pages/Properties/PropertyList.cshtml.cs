using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebImoveis.Domain.Entities;

namespace WebImoveis.WebApp.Pages.Properties
{
    public class PropertyListModel : PageModel
    {
        private readonly WebImoveis.Data.Contexts.ApplicationDbContext _context;
        public IList<Property> Properties { get; set; }

        [BindProperty]
        public string SearchByName { get; set; }

        [BindProperty]
        public string SearchByCep { get; set; }

        public PropertyListModel(WebImoveis.Data.Contexts.ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnPostCepFilterAsync()
        {
            Properties = _context.Properties.Where(p => p.Address.Cep == SearchByCep).Include(p => p.Address).ToList();
            ViewData["Address"] = new SelectList(_context.Properties.Select(p => p.Address.Cep).Distinct().ToList());
        }

        public void OnPostBtnFilterAsync()
        {
            Properties = _context.Properties.Where(p => p.Name.Contains(SearchByName)).Include(p => p.Address).ToList();
            ViewData["Address"] = new SelectList(_context.Properties.Select(p => p.Address.Cep).Distinct().ToList());
        }

        public async Task OnGetAsync(string sortOrder)
        {
            ViewData["name"] = string.IsNullOrEmpty(sortOrder) ? "nameDesc" : "";
            ViewData["description"] = sortOrder == "Description" ? "descDesc" : "descAsc";

            IQueryable<Property> properties = from p in _context.Properties select p;

            switch (sortOrder)
            {
                case "nameDesc":
                    properties = properties.OrderByDescending(p => p.Name);
                    break;
                case "descDesc":
                    properties = properties.OrderByDescending(p => p.Description);
                    break;
                case "descAsc":
                    properties = properties.OrderBy(p => p.Description);
                    break;
                default:
                    properties = properties.OrderBy(p => p.Name);
                    break;
            }
            ViewData["Address"] = new SelectList(_context.Properties.Select(p => p.Address.Cep).Distinct().ToList());
            Properties = await properties.Include(p => p.Address).AsNoTracking().ToListAsync();
        }
    }
}
