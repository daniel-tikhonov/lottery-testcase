using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySimulator.Game.Models
{
    public class GameResponse
    {
        public bool IsRoundCompleted { get; set; }
        public bool Win { get; set; }
        public int Amount { get; set; }
    }
}
