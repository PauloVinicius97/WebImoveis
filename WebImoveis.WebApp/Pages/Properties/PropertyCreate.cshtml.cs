using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using WebImoveis.Application.Services;
using WebImoveis.Domain.Entities;

namespace WebImoveis.WebApp.Pages.Properties
{
    public class PropertyCreateModel : PageModel
    {
        private readonly WebImoveis.Data.Contexts.ApplicationDbContext _context;
        public static string _cepTemp;

        [BindProperty]
        public Property Property { get; set; }

        [BindProperty]
        public Address Address { get; set; }

        public PropertyCreateModel(WebImoveis.Data.Contexts.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "Cep");
            return Page();
        }

        public void OnPostBtnGetCepData()
        {
            _cepTemp = Address.Cep;

            Address = GetCepFromAPI.GetAddressFromJson(_cepTemp);

            ViewData["mensagem"] = "CEP não existe ou a API tá com erro.";
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "Cep");

            if (Address != null)
            {
                ViewData["cep"] = Address.Cep;
                ViewData["rua"] = Address.Street;
                ViewData["bairro"] = Address.Neighborhood;
                ViewData["cidade"] = Address.Town;
                ViewData["uf"] = Address.Uf;
                ViewData["mensagem"] = "CEP capturado com sucesso.";

                ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "Cep");
            }
        }

        public async Task<IActionResult> OnPostBtnSaveCepData()
        {
            ViewData["mensagem"] = "CEP já existe no banco de dados ou tu não digitou nada.";

            if (_cepTemp != null && !_context.Addresses.Any(a => a.Cep == _cepTemp))
            {
                Address = GetCepFromAPI.GetAddressFromJson(_cepTemp);

                _context.Addresses.Add(Address);
                await _context.SaveChangesAsync();

                ViewData["mensagem"] = "CEP adicionado com sucesso.";
                ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "Cep");

                ViewData["cep"] = "";
                ViewData["rua"] = "";
                ViewData["bairro"] = "";
                ViewData["cidade"] = "";
                ViewData["uf"] = "";

                _cepTemp = null;

                return Page();
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "Cep");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostBtnAddPropertyAsync()
        {
            if (_context.Properties.Any(p => p.AddressId == Property.AddressId) && _context.Properties.Any(p => p.Number == Property.Number))
            {
                ViewData["mensagem"] = "Já existe uma casa com o mesmo número neste endereço.";
                ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "Cep");

                return Page();
            }

            ViewData["mensagem"] = "Propriedade adicionada com sucesso.";
            _context.Properties.Add(Property);
            await _context.SaveChangesAsync();
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "Cep");

            return Page();
        }
    }
}
