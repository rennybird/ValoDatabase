using Microsoft.EntityFrameworkCore;
using ValoDatabase.Data;

namespace ValoDatabase.Models;

public static class SeedPlayerstat
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ValoDatabaseContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ValoDatabaseContext>>()))
        {
            if (context == null || context.Agent == null)
            {
                throw new ArgumentNullException("Null ValoDatabaseContext");
            }

            if (context.PlayerStat.Any())
            {
                return;   // DB has been seeded
            }

            context.PlayerStat.AddRange(
    new PlayerStat
    {
        PlayerID = 1,
        MatchID = 1,
        AgentID = 1,
        Kills = 20,
        Deaths = 13,
        Assists = 7,
        Headshots = 30,
        AVGDamageperRound = 242
    },
    new PlayerStat
    {
        PlayerID = 2,
        MatchID = 2,
        AgentID = 1,
        Kills = 11,
        Deaths = 17,
        Assists = 1,
        Headshots = 18,
        AVGDamageperRound = 93
    },
    new PlayerStat
    {
        PlayerID = 3,
        MatchID = 3,
        AgentID = 1,
        Kills = 22,
        Deaths = 19,
        Assists = 7,
        Headshots = 16,
        AVGDamageperRound = 150
    },
    new PlayerStat
    {
        PlayerID = 4,
        MatchID = 4,
        AgentID = 4,
        Kills = 8,
        Deaths = 10,
        Assists = 4,
        Headshots = 14,
        AVGDamageperRound = 87
    },
    new PlayerStat
    {
        PlayerID = 5,
        MatchID = 5,
        AgentID = 6,
        Kills = 10,
        Deaths = 12,
        Assists = 14,
        Headshots = 21,
        AVGDamageperRound = 122
    },
    new PlayerStat
    {
        PlayerID = 6,
        MatchID = 6,
        AgentID = 4,
        Kills = 16,
        Deaths = 18,
        Assists = 11,
        Headshots = 21,
        AVGDamageperRound = 147
    }
);
context.SaveChanges();

        }
    }
    }

