using System.ComponentModel.DataAnnotations;

namespace DemoCrudWebApi.Models
{
    public class PlayersModel
    {
        [Key]
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public int PlayerAge { get; set; }
        public string PlayerAddress { get; set; }
        public DateTime PlayerJoiningDate { get; set; }
    }
}
