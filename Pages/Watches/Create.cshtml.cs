using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using decebaleduard.Data;
using decebaleduard.Models;

namespace decebaleduard.Pages.Watches
{
    public class CreateModel : PageModel
    {
        private readonly decebaleduard.Data.decebaleduardContext _context;

        public CreateModel(decebaleduard.Data.decebaleduardContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["StoreID"] = new SelectList(_context.Store, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Watch Watch { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Watch.Add(Watch);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
