using LotterySimulator.Game.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySimulator.Game.Models
{
    /// <summary>
    /// Ball model
    /// </summary>
    public class BallModel
    {
        /// <summary>
        /// Ball type
        /// </summary>
        public BallTypes Type { get; set; }

        public BallModel(BallTypes type)
        {
            Type = type;
        }
    }
}
