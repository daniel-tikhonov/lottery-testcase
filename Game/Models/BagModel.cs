using LotterySimulator.Game.Enums;
using LotterySimulator.Settings;
using LotterySimulator.Shuffler.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySimulator.Game.Models
{
    /// <summary>
    /// Model represents bag and operations
    /// </summary>
    public class BagModel
    {
        private readonly IShuffler _shuffler;

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="shuffler">Shuffler used for shuffling bag</param>
        public BagModel(IShuffler shuffler) {
            _shuffler = shuffler;
            Balls = new List<BallModel>();
        }
        /// <summary>
        /// All balls in bag
        /// </summary>
        private List<BallModel> Balls { get; set; }
        /// <summary>
        /// Amount of balls in bag
        /// </summary>
        public int BallsCount => Balls.Count;
        /// <summary>
        /// Add balls to bag builder method
        /// </summary>
        /// <param name="count">Amount of balls</param>
        /// <param name="type">Type of balls to add</param>
        /// <returns>Updated bag model</returns>
        public BagModel AddBalls(int count, BallTypes type)
        {
            for (var i = 0; i < count; i++)
            {
                Balls.Add(new BallModel(type));
            }
            return this;
        }
        /// <summary>
        /// Shuffle balls
        /// </summary>
        /// <param name="settings">Shuffle settings</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public async Task Shuffle(ShuffleSettings settings, CancellationToken ct)
        {
            Balls = (await _shuffler.Shuffle(Balls, settings, ct)).ToList();
        }
        /// <summary>
        /// Get ball from bag by index
        /// </summary>
        /// <param name="index">Ball index</param>
        /// <returns></returns>
        public BallModel Get(int index)
        {
            return Balls[index];
        }
    }
}
