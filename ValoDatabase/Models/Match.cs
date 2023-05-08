using System.ComponentModel.DataAnnotations;

namespace ValoDatabase.Models
{
    public class Match
    {
        public int Id { get; set; }
        
        public int MatchID { get; set; }
        public string Map { get; set; }
        public string Result { get; set; }
        public string Score { get; set; }
        public ICollection<PlayerStat> PlayerStats { get; set; } // add this property
    }
}
