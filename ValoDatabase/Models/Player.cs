using System.ComponentModel.DataAnnotations;

namespace ValoDatabase.Models
{
    public class Player
    {
        public int Id { get; set; }
        
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public string InGameName { get; set; }
        public string Team { get; set; }
        public string Region { get; set; }
        public ICollection<PlayerStat> PlayerStats { get; set; } // add this property
    }
}
