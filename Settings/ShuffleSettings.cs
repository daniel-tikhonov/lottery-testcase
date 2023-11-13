using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySimulator.Settings
{
    /// <summary>
    /// Extra shuffle settings
    /// </summary>
    public class ShuffleSettings
    {
        /// <summary>
        /// Amount of times of the bag shuffling
        /// </summary>
        public int Iterations { get; set; } = 1;
    }
}
