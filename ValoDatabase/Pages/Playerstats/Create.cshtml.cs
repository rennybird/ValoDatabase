using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ValoDatabase.Data;
using ValoDatabase.Models;

namespace ValoDatabase.Pages.Playerstats
{
    public class CreateModel : PageModel
    {
        private readonly ValoDatabase.Data.ValoDatabaseContext _context;

        public CreateModel(ValoDatabase.Data.ValoDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PlayerStat PlayerStat { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.PlayerStat == null || PlayerStat == null)
            {
                return Page();
            }

            _context.PlayerStat.Add(PlayerStat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
