using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ValoDatabase.Data;
using ValoDatabase.Models;

namespace ValoDatabase.Pages
{
    public class ComparePlayersModel : PageModel
    {
        private readonly ValoDatabaseContext _context;

        public ComparePlayersModel(ValoDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int Player1Id { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Player2Id { get; set; }

        public PlayerStat Player1Stats { get; set; }
        public PlayerStat Player2Stats { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Player1Stats = await _context.PlayerStat
                .Include(p => p.Player)
                .Include(p => p.Match)
                .Include(p => p.Agent)
                .FirstOrDefaultAsync(p => p.PlayerID == Player1Id);


            Player2Stats = await _context.PlayerStat
                .Include(p => p.Player)
                .Include(p => p.Match)
                .Include(p => p.Agent)
                .FirstOrDefaultAsync(p => p.PlayerID == Player2Id);

            if (Player1Stats == null || Player2Stats == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
