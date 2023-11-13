using LotterySimulator.Randomizer.Contracts;
using LotterySimulator.Settings;
using LotterySimulator.Shuffler.Contracts;

namespace LotterySimulator.Shuffler.Services
{
    /// <summary>
    /// Service for shuffling that implements Fisher Yates algorithm
    /// </summary>
    internal class FisherYatesShuffler : IShuffler
    {
        private readonly IRandomizer _randomizer;

        /// <summary>
        /// Main contructor
        /// </summary>
        /// <param name="randomizer">Provider for randomization</param>
        public FisherYatesShuffler(IRandomizer randomizer)
        {
            _randomizer = randomizer;
        }
        public async Task<IEnumerable<TModel>> Shuffle<TModel>(IEnumerable<TModel> data, ShuffleSettings options, CancellationToken ct)
        {
            var arr = data.ToArray();
            for (var iterationIndex = 0; iterationIndex < options.Iterations; iterationIndex++)
            {
                
                int n = arr.Length;
                for (int i = 0; i < (n - 1); i++)
                {
                    int r = i + await _randomizer.RandomizeInt(0, n - i, ct);
                    TModel t = arr[r];
                    arr[r] = arr[i];
                    arr[i] = t;
                }
            }
            return arr;
            
        }
    }
}
