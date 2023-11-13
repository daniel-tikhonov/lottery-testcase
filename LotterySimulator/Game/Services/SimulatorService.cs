using LotterySimulator.Game.Contracts;
using LotterySimulator.Game.Models;
using LotterySimulator.Settings;
using Microsoft.Extensions.Options;

namespace LotterySimulator.Game.Services
{
    internal class SimulatorService : ISimulatorService
    {
        private readonly IBagService _bagService;
        private readonly IOptions<GameSettings> _gameSettings;

        public SimulatorService(IBagService bagService, IOptions<GameSettings> gameSettings) {
            _bagService = bagService;
            _gameSettings = gameSettings;
        }
        public async Task<SimulateResponse> Simulate(int roundsCount, CancellationToken ct)
        {
            var options = Options.Create(new GameSettings()
            {
                IsSimulation = true,
                InitialBalance = _gameSettings.Value.InitialBalance,
                TryPrice = _gameSettings.Value.TryPrice,
                WinPrice = _gameSettings.Value.WinPrice
            });
            var gameService = new GameService(_bagService, options);
            decimal profit = 0;
            decimal spent = 0;
            for (int i = 0; i< roundsCount; i++)
            {
                var gameResult = await gameService.Play(ct);
                if (!gameResult.IsRoundCompleted)
                {
                    i--;
                    continue;
                }
                spent += options.Value.TryPrice;
                if (gameResult.Win)
                {
                    profit += options.Value.WinPrice;
                }
            }
            return new SimulateResponse()
            {
                Rtp = (profit / spent) * 100
            };
        }
    }
}
