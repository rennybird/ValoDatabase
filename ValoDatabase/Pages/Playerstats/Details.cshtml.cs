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
    public class DetailsModel : PageModel
    {
        private readonly ValoDatabase.Data.ValoDatabaseContext _context;

        public DetailsModel(ValoDatabase.Data.ValoDatabaseContext context)
        {
            _context = context;
        }

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
    }
}
