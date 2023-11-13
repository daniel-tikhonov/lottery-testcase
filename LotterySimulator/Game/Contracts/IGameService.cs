using LotterySimulator.Game.Models;

namespace LotterySimulator.Game.Contracts
{
    public interface IGameService
    {
        int Balance { get; }
        Task<GameResponse> Play(CancellationToken ct);
    }
}
