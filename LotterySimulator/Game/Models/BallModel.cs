using LotterySimulator.Game.Enums;

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
