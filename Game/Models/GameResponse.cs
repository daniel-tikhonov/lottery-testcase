using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySimulator.Game.Models
{
    /// <summary>
    /// Game response
    /// </summary>
    public class GameResponse
    {
        /// <summary>
        /// Flag indicates that round completed, win or lose result occured
        /// </summary>
        public bool IsRoundCompleted { get; set; }
        /// <summary>
        /// Flag indicates that win the round otherwise false (lose)
        /// </summary>
        public bool Win { get; set; }
    }
}
