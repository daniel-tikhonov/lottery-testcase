using LotterySimulator.Randomizer.Contracts;

namespace LotterySimulator.Randomizer.Services
{
    internal class LocalRandomizer : IRandomizer
    {
        private Random _randomizer;
        public LocalRandomizer() {
            _randomizer = new Random();

        }
        public async Task<int> RandomizeInt(int min, int max, CancellationToken ct)
        {
            return _randomizer.Next(min, max);
        }
    }
}
