using LotterySimulator.Exceptions;
using LotterySimulator.Game.Contracts;
using LotterySimulator.Game.Models;
using LotterySimulator.Settings;
using Microsoft.Extensions.Options;

namespace LotterySimulator.Game.Services
{
    internal class GameService : IGameService
    {
        private readonly IBagService _bagService;
        private readonly IOptions<GameSettings> _settings;
        private BagModel _bag;
        public int Balance { get; private set; }

        public GameService(IBagService bagService, IOptions<GameSettings> settings) {
            _bagService = bagService;
            _settings = settings;
            Balance = settings.Value.InitialBalance;
            _bag = bagService.CreateBag();
        }
        public async Task<GameResponse> Play(CancellationToken ct)
        {
            if (!_settings.Value.IsSimulation && Balance < _settings.Value.TryPrice)
            {
                throw new OutOfBalanceException();
            }
            var ball = await _bagService.DrawBall(_bag, ct);
            switch (ball.Type)
            {
                case Enums.BallTypes.Win:
                    {
                        if (!_settings.Value.IsSimulation)
                        {
                            Balance += _settings.Value.WinPrice - _settings.Value.TryPrice;
                        }                        
                        return new GameResponse()
                        {
                            IsRoundCompleted = true,
                            Win = true
                        };
                    }
                case Enums.BallTypes.Lose:
                    {
                        if (!_settings.Value.IsSimulation)
                        {
                            Balance -= _settings.Value.TryPrice;
                        }
                        return new GameResponse()
                        {
                            IsRoundCompleted = true,
                            Win = false
                        };
                    }
                case Enums.BallTypes.ExtraTry:
                    {
                        return new GameResponse()
                        {
                            IsRoundCompleted = false
                        };
                    }
                default:
                    {
                        throw new InvalidDataException("Unknown ball type");
                    }
            }
        }
    }
}
