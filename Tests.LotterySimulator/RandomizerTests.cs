using LotterySimulator.Randomizer.Services;

namespace Tests.LotterySimulator
{
    [TestClass]
    public class RandomizerTests
    {
        [TestMethod]
        public async Task LocalRandomizerGenerateInt_MinMaxRangeSpecified_Success()
        {
            var randomizer = new LocalRandomizer();
            var randomInt = await randomizer.RandomizeInt(0, 1, default);
            Assert.IsTrue(randomInt >= 0);
            Assert.IsTrue(randomInt <= 1);
        }
    }
}