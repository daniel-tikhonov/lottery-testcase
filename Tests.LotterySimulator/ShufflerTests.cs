using LotterySimulator.Randomizer.Contracts;
using LotterySimulator.Randomizer.Services;
using LotterySimulator.Settings;
using LotterySimulator.Shuffler.Services;
using Moq;

namespace Tests.LotterySimulator
{
    [TestClass]
    public class ShufflerTests
    {
        [TestMethod]
        public async Task FisherYatesShufflerShuffle_FakeRandomizerSingleIteration_Success()
        {
            var cancellatioToken = new CancellationToken();
            var data = new string[] { "a", "b", "c" };
            var randomizerMock = new Mock<IRandomizer>();
            randomizerMock.Setup(_ => _.RandomizeInt(0, 3, cancellatioToken)).Returns(Task.FromResult(1));
            randomizerMock.Setup(_ => _.RandomizeInt(0, 2, cancellatioToken)).Returns(Task.FromResult(0));
            var shuffler = new FisherYatesShuffler(randomizerMock.Object);
            var array = (await shuffler.Shuffle(data, new ShuffleSettings()
            {
                Iterations = 1
            }, cancellatioToken)).ToList();
            randomizerMock.Verify(_ => _.RandomizeInt(It.IsAny<int>(), It.IsAny<int>(), cancellatioToken), Times.Exactly(2));
            randomizerMock.Verify(_ => _.RandomizeInt(0, 3, cancellatioToken), Times.Once);
            randomizerMock.Verify(_ => _.RandomizeInt(0, 2, cancellatioToken), Times.Once);
            Assert.AreEqual(array[0], "b");
            Assert.AreEqual(array[1], "a");
            Assert.AreEqual(array[2], "c");
        }
    }
}