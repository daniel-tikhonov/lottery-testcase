using LotterySimulator.Game.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySimulator.Game.Models
{
    public class BallModel
    {
        public BallTypes Type { get; set; }

        public BallModel(BallTypes type)
        {
            Type = type;
        }
    }
}
