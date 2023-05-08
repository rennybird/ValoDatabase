using System.ComponentModel.DataAnnotations;

namespace ValoDatabase.Models
{
    public class Agent
    {
        public int Id { get; set; }
       
        public int AgentID { get; set; }
        public string Name { get; set; }
        public ICollection<PlayerStat> PlayerStats { get; set; } = new List<PlayerStat>();
    }
}
