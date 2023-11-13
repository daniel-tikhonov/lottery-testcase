using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySimulator.Settings
{
    /// <summary>
    /// Settings that describes balls bag content
    /// </summary>
    internal class BagSettings
    {
        /// <summary>
        /// Amount of winning balls
        /// </summary>
        public int Win { get; set; }
        /// <summary>
        /// Amount of losing balls
        /// </summary>
        public int Lose { get; set; }
        /// <summary>
        /// Amount of extra try balls
        /// </summary>
        public int ExtraTry { get; set; }
    }
}
