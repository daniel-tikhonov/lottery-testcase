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
    public class BagModel
    {
        private readonly IShuffler _shuffler;

        public BagModel(IShuffler shuffler) {
            _shuffler = shuffler;
            Balls = new List<BallModel>();
        }
        private List<BallModel> Balls { get; set; }
        public int BallsCount => Balls.Count;
        public BagModel AddBalls(int count, BallTypes type)
        {
            for (var i = 0; i < count; i++)
            {
                Balls.Add(new BallModel(type));
            }
            return this;
        }
        public async Task Shuffle(ShuffleSettings settings, CancellationToken ct)
        {
            Balls = (await _shuffler.Shuffle(Balls, settings, ct)).ToList();
        }
        public BallModel Get(int index)
        {
            return Balls[index];
        }
    }
}
