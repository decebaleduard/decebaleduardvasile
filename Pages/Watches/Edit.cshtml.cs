using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using decebaleduard.Data;
using decebaleduard.Models;

namespace decebaleduard.Pages.Watches
{
    public class EditModel : PageModel
    {
        private readonly decebaleduard.Data.decebaleduardContext _context;

        public EditModel(decebaleduard.Data.decebaleduardContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Watch Watch { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Watch == null)
            {
                return NotFound();
            }

            var watch =  await _context.Watch.FirstOrDefaultAsync(m => m.Id == id);
            if (watch == null)
            {
                return NotFound();
            }
            Watch = watch;
           ViewData["StoreID"] = new SelectList(_context.Store, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Watch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WatchExists(Watch.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WatchExists(int id)
        {
          return _context.Watch.Any(e => e.Id == id);
        }
    }
}
