using LotterySimulator.Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySimulator.Game.Contracts
{
    public interface IBagService
    {
        Task<BallModel> DrawBall(BagModel bag, CancellationToken ct);
        BagModel CreateBag();
    }
}
