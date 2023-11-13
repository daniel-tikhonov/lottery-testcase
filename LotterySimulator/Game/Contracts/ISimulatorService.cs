using LotterySimulator.Game.Models;

namespace LotterySimulator.Game.Contracts
{
    /// <summary>
    /// Service for simulation user player
    /// </summary>
    internal interface ISimulatorService
    {
        /// <summary>
        /// Method that simulates user behaviour N round and returns statistic
        /// </summary>
        /// <param name="roundsCount">Amount of round to simulate</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Simulation statistic</returns>
        Task<SimulateResponse> Simulate(int roundsCount, CancellationToken ct);
    }
}
