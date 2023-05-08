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
    public class IndexModel : PageModel
    {
        private readonly ValoDatabase.Data.ValoDatabaseContext _context;

        public IndexModel(ValoDatabase.Data.ValoDatabaseContext context)
        {
            _context = context;
        }

        public IList<PlayerStat> PlayerStat { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PlayerStat != null)
            {
                PlayerStat = await _context.PlayerStat.ToListAsync();
            }
        }
    }
}
