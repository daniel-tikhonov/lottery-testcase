using LotterySimulator.Randomizer.Contracts;

namespace LotterySimulator.Randomizer.Services
{
    /// <summary>
    /// Randomizer that using clasic .net pseudo randomization algorithm by system clock
    /// </summary>
    internal class LocalRandomizer : IRandomizer
    {
        private Random _randomizer;
        /// <summary>
        /// Default contructor
        /// </summary>
        public LocalRandomizer() {
            _randomizer = new Random();

        }
        public async Task<int> RandomizeInt(int min, int max, CancellationToken ct)
        {
            return _randomizer.Next(min, max);
        }
    }
}
