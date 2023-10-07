using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Entities.DTO
{
    public class GamePlayRequestDTO
    {
        public GamePlayRequestDTO() { }
        public int IdDuel { get; set; }
        public int OptionValuePlayer1 { get; set; }
        public int OptionValuePlayer2 { get; set; }
    }
}
