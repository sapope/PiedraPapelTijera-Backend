using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Test.Entities.Core
{
    public class Duels
    {
        public Duels()
        {
            Plays = new HashSet<Plays>();
        }
        [Key]
        public int Id { get; set; }
        public int IdPlayer1 { get; set; }
        public int IdPlayer2 { get; set; }
        public int ScorePlayer1 { get; set; }
        public int ScorePlayer2 { get; set; }
        [JsonIgnore]
        public virtual Players Player1 { get; set; }
        [JsonIgnore]
        public virtual Players Player2 { get; set; }
        [JsonIgnore]
        public virtual ICollection<Plays> Plays { get; set; }

    }
}
