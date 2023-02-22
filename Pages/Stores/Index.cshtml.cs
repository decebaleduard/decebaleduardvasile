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
    public class IndexModel : PageModel
    {
        private readonly decebaleduard.Data.decebaleduardContext _context;

        public IndexModel(decebaleduard.Data.decebaleduardContext context)
        {
            _context = context;
        }

        public IList<Store> Store { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Store != null)
            {
                Store = await _context.Store.ToListAsync();
            }
        }
    }
}
