using decebaleduard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace decebaleduard.Pages.Stores
{
    public class DetailsModel : PageModel
    {
        private readonly decebaleduard.Data.decebaleduardContext _context;

        public DetailsModel(decebaleduard.Data.decebaleduardContext context)
        {
            _context = context;
        }

        public Store Store { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Store == null)
            {
                return NotFound();
            }

            var store = await _context.Store.FirstOrDefaultAsync(m => m.ID == id);
            if (store == null)
            {
                return NotFound();
            }
            else
            {
                Store = store;
            }
            return Page();
        }
    }
}
