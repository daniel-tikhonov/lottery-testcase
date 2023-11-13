using LotterySimulator.Game.Contracts;
using LotterySimulator.Game.Models;
using LotterySimulator.Randomizer.Contracts;
using LotterySimulator.Settings;
using LotterySimulator.Shuffler.Contracts;
using Microsoft.Extensions.Options;

namespace LotterySimulator.Game.Services
{
    /// <summary>
    /// Main lottery bag service
    /// </summary>
    internal class BagService : IBagService
    {
        private readonly IOptions<BagSettings> _settings;
        private readonly IOptions<ShuffleSettings> _shufflerSettings;
        private readonly IShuffler _shuffler;
        private readonly IRandomizer _randomizer;

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="settings">Bag settings</param>
        /// <param name="shufflerSettings">Shuffler settings</param>
        /// <param name="shuffler">Shuffler</param>
        /// <param name="randomizer">Randomizer</param>
        public BagService(IOptions<BagSettings> settings, IOptions<ShuffleSettings> shufflerSettings, IShuffler shuffler, IRandomizer randomizer)
        {
            _settings = settings;
            _shufflerSettings = shufflerSettings;
            _shuffler = shuffler;
            _randomizer = randomizer;
        }

        public BagModel CreateBag()
        {
            return new BagModel(_shuffler)
                        .AddBalls(_settings.Value.Win, Enums.BallTypes.Win)
                        .AddBalls(_settings.Value.ExtraTry, Enums.BallTypes.ExtraTry)
                        .AddBalls(_settings.Value.Lose, Enums.BallTypes.Lose);
        }

        public async Task<BallModel> DrawBall(BagModel bag, CancellationToken ct)
        {
            
            await bag.Shuffle(_shufflerSettings.Value, ct);
            return bag.Get(await _randomizer.RandomizeInt(0, bag.BallsCount - 1, ct));
        }
    }
}
