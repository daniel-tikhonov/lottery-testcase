using LotterySimulator.Exceptions;
using LotterySimulator.Game.Contracts;
using LotterySimulator.Game.Enums;
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
    public class SimulatorServiceTests
    {
        [TestMethod]
        public async Task Simulate_ThreeRounds_Success()
        {
            CancellationToken ct = new CancellationToken();
            var gameSettings = Options.Create(new GameSettings() { InitialBalance = 200, TryPrice = 10, WinPrice = 20, IsSimulation = true });
            var bagServiceMock = new Mock<IBagService>();
            var shufflerMock = new Mock<IShuffler>();
            bagServiceMock.Setup(_ => _.CreateBag()).Returns(new BagModel(shufflerMock.Object));
            var drawCounter = 0;
            bagServiceMock.Setup(_ => _.DrawBall(It.IsAny<BagModel>(), ct)).ReturnsAsync(() =>
            {
                if (drawCounter == 0)
                {
                    drawCounter++;
                    return new BallModel(BallTypes.Win);
                } else if(drawCounter == 1)
                {
                    drawCounter++;
                    return new BallModel(BallTypes.ExtraTry);
                } else
                {
                    return new BallModel(BallTypes.Lose);
                }
            });
            var gameService = new SimulatorService(bagServiceMock.Object, gameSettings);
            var res = await gameService.Simulate(3, ct);
            bagServiceMock.Verify(_ => _.CreateBag(), Times.Once);
            bagServiceMock.Verify(_ => _.DrawBall(It.IsAny<BagModel>(), ct), Times.Exactly(4));
            Assert.AreEqual(res.WinAmount, 20);
            Assert.AreEqual(res.SpentAmount, 30);
        }
    }
}