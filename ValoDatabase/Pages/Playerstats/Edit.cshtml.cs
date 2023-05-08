using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ValoDatabase.Data;
using ValoDatabase.Models;

namespace ValoDatabase.Pages.Playerstats
{
    public class EditModel : PageModel
    {
        private readonly ValoDatabase.Data.ValoDatabaseContext _context;

        public EditModel(ValoDatabase.Data.ValoDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PlayerStat PlayerStat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PlayerStat == null)
            {
                return NotFound();
            }

            var playerstat =  await _context.PlayerStat.FirstOrDefaultAsync(m => m.Id == id);
            if (playerstat == null)
            {
                return NotFound();
            }
            PlayerStat = playerstat;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PlayerStat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerStatExists(PlayerStat.Id))
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

        private bool PlayerStatExists(int id)
        {
          return (_context.PlayerStat?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
