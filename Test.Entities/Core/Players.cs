using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Test.Entities.Core
{
    public class Players
    {
        public Players()
        {
            Duels_Player1 = new HashSet<Duels>();
            Duels_Player2 = new HashSet<Duels>();
            Plays = new HashSet<Plays>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name {get; set; }
        [JsonIgnore]
        public virtual ICollection<Duels> Duels_Player1 { get; set; }
        [JsonIgnore]
        public virtual ICollection<Duels> Duels_Player2 { get; set; }
        [JsonIgnore]
        public virtual ICollection<Plays> Plays { get; set; }
    }
}
