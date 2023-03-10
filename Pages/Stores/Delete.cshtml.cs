using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using decebaleduard.Data;
using decebaleduard.Models;

namespace decebaleduard.Pages.Stores
{
    public class DeleteModel : PageModel
    {
        private readonly decebaleduard.Data.decebaleduardContext _context;

        public DeleteModel(decebaleduard.Data.decebaleduardContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Store == null)
            {
                return NotFound();
            }
            var store = await _context.Store.FindAsync(id);

            if (store != null)
            {
                Store = store;
                _context.Store.Remove(Store);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
