using Microsoft.EntityFrameworkCore;
using ValoDatabase.Data;
using ValoDatabase.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ValoDatabaseContext(
            serviceProvider.GetRequiredService<DbContextOptions<ValoDatabaseContext>>()))
        {
            //Delete a new database
            context.Database.EnsureDeleted();

            // Create a new database
            context.Database.EnsureCreated();
            if (context == null || context.Agent == null)
            {
                throw new ArgumentNullException("Null ValoDatabaseContext");
            }

            // Look for any agents.
            if (!context.Agent.Any())
            {
                context.Agent.AddRange(
                    new Agent { AgentID = 1, Name = "Jett" },
                    new Agent { AgentID = 2, Name = "Reyna" },
                    new Agent { AgentID = 3, Name = "Raze" },
                    new Agent { AgentID = 4, Name = "Viper" },
                    new Agent { AgentID = 5, Name = "Sova" },
                    new Agent { AgentID = 6, Name = "Brimstone" }
                );
                context.SaveChanges();
            }

            // Look for any players.
            if (!context.Player.Any())
            {
                context.Player.AddRange(
                    new Player
                    {
                        PlayerID = 1,
                        Name = "Kantapong Kingthong",
                        InGameName = "Kadoom",
                        Team = "MITH",
                        Region = "APAC"
                    },

                    new Player
                    {
                        PlayerID = 2,
                        Name = "Chanawin Nakchain",
                        InGameName = "JohnOlsen",
                        Team = "Full Sense",
                        Region = "APAC"
                    },

                    new Player
                    {
                        PlayerID = 3,
                        Name = "Mark Saif Jibraeel",
                        InGameName = "Sayf",
                        Team = "Team Liquid",
                        Region = "EMEA"
                    },

                    new Player
                    {
                        PlayerID = 4,
                        Name = "Jake Howlett",
                        InGameName = "Boaster",
                        Team = "Fnatic",
                        Region = "EMEA"
                    },

                    new Player
                    {
                        PlayerID = 5,
                        Name = "Nutchapon Matarat",
                        InGameName = "sScary",
                        Team = "Bleed Esport",
                        Region = "APAC"
                    },

                    new Player
                    {
                        PlayerID = 6,
                        Name = "Trent Cairns",
                        InGameName = "trent",
                        Team = "The Guard",
                        Region = "Americas"
                    }
                );
                context.SaveChanges();
            }

            if (!context.Match.Any())
            {
                context.Match.AddRange(
                    new Match { MatchID = 1, Map = "Ascent", Result = "Win", Score = "13-4" },
                    new Match { MatchID = 2, Map = "Haven", Result = "Win", Score = "13-11" },
                    new Match { MatchID = 3, Map = "Ascent", Result = "Loss", Score = "11-13" },
                    new Match { MatchID = 4, Map = "Icebox", Result = "Win", Score = "13-5" },
                    new Match { MatchID = 5, Map = "Bind", Result = "Win", Score = "13-4" },
                    new Match { MatchID = 6, Map = "Split", Result = "Win", Score = "13-11" },
                    new Match { MatchID = 7, Map = "Ascent", Result = "Win", Score = "13-2" }
                );
                context.SaveChanges();
            }

            // Look for any player stats.
            if (!context.PlayerStat.Any())
            {
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
}
            