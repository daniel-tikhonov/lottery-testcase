using LotterySimulator.Game.Models;

namespace LotterySimulator.Game.Contracts
{
    internal interface ISimulatorService
    {
        Task<SimulateResponse> Simulate(int roundsCount, CancellationToken ct);
    }
}
