using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySimulator.Game.Models
{
    /// <summary>
    /// Simultaion statistic
    /// </summary>
    public class SimulateResponse
    {
        /// <summary>
        /// return to player
        /// RTP = ( (number of won credits) / (number of credits that are spent to play the game))*100.
        /// </summary>
        public decimal Rtp { get; set; }
        /// <summary>
        /// Amount of money user won during simulation
        /// </summary>
        public decimal WinAmount { get; set; }
        /// <summary>
        /// Amount of money user spent during simulation
        /// </summary>
        public decimal SpentAmount { get; set; }
    }
}
