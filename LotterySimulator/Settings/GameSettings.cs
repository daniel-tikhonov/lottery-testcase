using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySimulator.Settings
{
    /// <summary>
    /// Settings describes the whole game
    /// </summary>
    internal class GameSettings
    {
        /// <summary>
        /// Flag indicates that game in simulation mode, game balance ignored
        /// </summary>
        public bool IsSimulation { get; set; }
        /// <summary>
        /// Amount of money user will spent for roll
        /// </summary>
        public int TryPrice { get; set; }
        /// <summary>
        /// Amount of money user will win
        /// </summary>
        public int WinPrice { get; set; }
        /// <summary>
        /// Users initial balance
        /// </summary>
        public int InitialBalance { get; set; }
    }
}
