﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ValoDatabase.Data;
using ValoDatabase.Models;

namespace ValoDatabase.Pages.Agents
{
    public class DeleteModel : PageModel
    {
        private readonly ValoDatabase.Data.ValoDatabaseContext _context;

        public DeleteModel(ValoDatabase.Data.ValoDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Agent Agent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Agent == null)
            {
                return NotFound();
            }

            var agent = await _context.Agent.FirstOrDefaultAsync(m => m.Id == id);

            if (agent == null)
            {
                return NotFound();
            }
            else 
            {
                Agent = agent;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Agent == null)
            {
                return NotFound();
            }
            var agent = await _context.Agent.FindAsync(id);

            if (agent != null)
            {
                Agent = agent;
                _context.Agent.Remove(Agent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
