using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ValoDatabase.Models;

namespace ValoDatabase.Data
{
    public class ValoDatabaseContext : DbContext
    {
        public ValoDatabaseContext (DbContextOptions<ValoDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<ValoDatabase.Models.Agent> Agent { get; set; } = default!;

        public DbSet<ValoDatabase.Models.Match> Match { get; set; } = default!;

        public DbSet<ValoDatabase.Models.Player> Player { get; set; } = default!;

        public DbSet<ValoDatabase.Models.PlayerStat> PlayerStat { get; set; } = default!;
    }
}
