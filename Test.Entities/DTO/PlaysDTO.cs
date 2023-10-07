using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Entities.DTO
{
    public class PlaysDTO
    {
        public int Id { get; set; }
        public int IdDuel { get; set; }
        public int IdPlayer { get; set; }
        public int Step { get; set; }
        public int OptionValue { get; set; }
    }
}
