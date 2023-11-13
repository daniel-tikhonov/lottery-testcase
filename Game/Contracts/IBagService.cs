using LotterySimulator.Game.Models;

namespace LotterySimulator.Game.Contracts
{
    /// <summary>
    /// Service managing bag operations
    /// </summary>
    public interface IBagService
    {
        /// <summary>
        /// Draw a random ball
        /// </summary>
        /// <param name="bag">Source bag with balls</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Random ball</returns>
        Task<BallModel> DrawBall(BagModel bag, CancellationToken ct);
        /// <summary>
        /// Creates bag according to config values
        /// </summary>
        /// <returns></returns>
        BagModel CreateBag();
    }
}
