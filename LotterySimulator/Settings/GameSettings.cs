using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySimulator.Settings
{
    internal class GameSettings
    {
        public bool IsSimulation { get; set; }
        public int TryPrice { get; set; }
        public int WinPrice { get; set; }
        public int InitialBalance { get; set; }
    }
}
