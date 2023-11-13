using LotterySimulator.Game.Models;

namespace LotterySimulator.Game.Contracts
{
    /// <summary>
    /// Service controlling the whole game flow
    /// </summary>
    public interface IGameService
    {
        /// <summary>
        /// User's balance
        /// </summary>
        int Balance { get; }
        /// <summary>
        /// Make a roll for user
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Information about game result</returns>
        Task<GameResponse> Play(CancellationToken ct);
    }
}
