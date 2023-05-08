using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ValoDatabase.Data;
using ValoDatabase.Models;

namespace ValoDatabase.Pages.Playerstats
{
    public class DeleteModel : PageModel
    {
        private readonly ValoDatabase.Data.ValoDatabaseContext _context;

        public DeleteModel(ValoDatabase.Data.ValoDatabaseContext context)
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

            var playerstat = await _context.PlayerStat.FirstOrDefaultAsync(m => m.Id == id);

            if (playerstat == null)
            {
                return NotFound();
            }
            else 
            {
                PlayerStat = playerstat;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PlayerStat == null)
            {
                return NotFound();
            }
            var playerstat = await _context.PlayerStat.FindAsync(id);

            if (playerstat != null)
            {
                PlayerStat = playerstat;
                _context.PlayerStat.Remove(PlayerStat);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
