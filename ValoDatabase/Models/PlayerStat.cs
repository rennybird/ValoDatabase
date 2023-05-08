using System.ComponentModel.DataAnnotations;

namespace ValoDatabase.Models
{
    public class PlayerStat
    {
        public int Id { get; set; }
        
        public int PlayerID { get; set; }
        
        public int MatchID { get; set; }
        
        public int AgentID { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public int Headshots { get; set; }
        public int AVGDamageperRound { get; set; }
        public Player Player { get; set; } // add this property

        public Match Match { get; set; }
        public Agent Agent { get; set; }
    }
}
