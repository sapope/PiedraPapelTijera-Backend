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
    public class Plays
    {
        public Plays()
        { 
        
        }
        [Key]
        public int Id { get; set; }
        public int IdDuel { get; set; }
        public int IdPlayer { get; set; }
        public int Step { get; set; }
        public int OptionValue { get; set; }
        [JsonIgnore]
        public virtual Duels Duels { get; set; }
        [JsonIgnore]
        public virtual Players Players { get; set; }
    }
}
