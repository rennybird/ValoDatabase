using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ValoDatabase.Data;
using ValoDatabase.Models;

namespace ValoDatabase.Pages.Matchs
{
    public class DeleteModel : PageModel
    {
        private readonly ValoDatabase.Data.ValoDatabaseContext _context;

        public DeleteModel(ValoDatabase.Data.ValoDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Match Match { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Match == null)
            {
                return NotFound();
            }

            var match = await _context.Match.FirstOrDefaultAsync(m => m.Id == id);

            if (match == null)
            {
                return NotFound();
            }
            else 
            {
                Match = match;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Match == null)
            {
                return NotFound();
            }
            var match = await _context.Match.FindAsync(id);

            if (match != null)
            {
                Match = match;
                _context.Match.Remove(Match);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
