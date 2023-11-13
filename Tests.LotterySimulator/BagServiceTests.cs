using LotterySimulator.Game.Models;
using LotterySimulator.Game.Services;
using LotterySimulator.Randomizer.Contracts;
using LotterySimulator.Settings;
using LotterySimulator.Shuffler.Contracts;
using Microsoft.Extensions.Options;
using Moq;

namespace Tests.LotterySimulator
{
    [TestClass]
    public class BagServiceTests
    {
        [TestMethod]
        public async Task CreateBag_ValidConfig_20BallsCreated()
        {
            var bagSettings = Options.Create(new BagSettings() { Win = 5, ExtraTry = 1, Lose = 14 });
            var shufflerSettings = Options.Create(new ShuffleSettings());
            var randomizerMock = new Mock<IRandomizer>();
            var shufflerMock = new Mock<IShuffler>();
            var bagService = new BagService(bagSettings, shufflerSettings, shufflerMock.Object, randomizerMock.Object);
            var bag = bagService.CreateBag();
            Assert.AreEqual(bag.BallsCount, 20);
        }
        [TestMethod]
        public async Task DrawBall_DrawSingleBall_BallReturned()
        {
            var fakeRandomBall = 3;
            var cancellationToken = new CancellationToken();
            var bagSettings = Options.Create(new BagSettings() { Win = 5, ExtraTry = 1, Lose = 14 });
            var shufflerSettings = Options.Create(new ShuffleSettings());
            var randomizerMock = new Mock<IRandomizer>();
            
            var shufflerMock = new Mock<IShuffler>();            
            var bagService = new BagService(bagSettings, shufflerSettings, shufflerMock.Object, randomizerMock.Object);
            var bag = bagService.CreateBag();
            randomizerMock.Setup(_ => _.RandomizeInt(0, 20, cancellationToken)).Returns(Task.FromResult(fakeRandomBall));
            shufflerMock.Setup(_ => _.Shuffle(It.IsAny<IEnumerable<BallModel>>(), shufflerSettings.Value, cancellationToken)).ReturnsAsync(bag.Balls);
            var drawResult = await bagService.DrawBall(bag, cancellationToken);
            randomizerMock.Verify(_ => _.RandomizeInt(0, 20, cancellationToken), Times.Once);
            shufflerMock.Verify(_ => _.Shuffle(It.IsAny<IEnumerable<BallModel>>(), shufflerSettings.Value, cancellationToken), Times.Once);
            Assert.AreEqual(drawResult, bag.Get(fakeRandomBall));
        }
    }
}