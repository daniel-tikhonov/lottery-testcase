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
    public class GameServiceTests
    {
        [TestMethod]
        public async Task Play_NotEnoughMoneyNotSimulation_ThrowException()
        {
            CancellationToken ct = new CancellationToken();
            var gameSettings = Options.Create(new GameSettings() { InitialBalance = 9, TryPrice = 10, WinPrice = 20 });
            var bagServiceMock = new Mock<IBagService>();
            var gameService = new GameService(bagServiceMock.Object, gameSettings);
            await Assert.ThrowsExceptionAsync<OutOfBalanceException>(async () =>
            {
                await gameService.Play(ct);
            });
        }
        [TestMethod]
        public async Task Play_RollWinBall_RolledWinBall()
        {
            CancellationToken ct = new CancellationToken();
            var gameSettings = Options.Create(new GameSettings() { InitialBalance = 200, TryPrice = 10, WinPrice = 20 });
            var bagServiceMock = new Mock<IBagService>();
            var shufflerMock = new Mock<IShuffler>();
            bagServiceMock.Setup(_ => _.CreateBag()).Returns(new BagModel(shufflerMock.Object));
            bagServiceMock.Setup(_ => _.DrawBall(It.IsAny<BagModel>(), ct)).Returns(Task.FromResult(new BallModel(BallTypes.Win)));
            var gameService = new GameService(bagServiceMock.Object, gameSettings);
            var res = await gameService.Play(ct);
            bagServiceMock.Verify(_ => _.CreateBag(), Times.Once);
            bagServiceMock.Verify(_ => _.DrawBall(It.IsAny<BagModel>(), ct), Times.Once);
            Assert.IsTrue(res.Win);
            Assert.IsTrue(res.IsRoundCompleted);
        }
        [TestMethod]
        public async Task Play_RollLoseBall_RolledLoseBall()
        {
            CancellationToken ct = new CancellationToken();
            var gameSettings = Options.Create(new GameSettings() { InitialBalance = 200, TryPrice = 10, WinPrice = 20 });
            var bagServiceMock = new Mock<IBagService>();
            var shufflerMock = new Mock<IShuffler>();
            bagServiceMock.Setup(_ => _.CreateBag()).Returns(new BagModel(shufflerMock.Object));
            bagServiceMock.Setup(_ => _.DrawBall(It.IsAny<BagModel>(), ct)).Returns(Task.FromResult(new BallModel(BallTypes.Lose)));
            var gameService = new GameService(bagServiceMock.Object, gameSettings);
            var res = await gameService.Play(ct);
            bagServiceMock.Verify(_ => _.CreateBag(), Times.Once);
            bagServiceMock.Verify(_ => _.DrawBall(It.IsAny<BagModel>(), ct), Times.Once);
            Assert.IsFalse(res.Win);
            Assert.IsTrue(res.IsRoundCompleted);
        }
        [TestMethod]
        public async Task Play_RollExtraTryBall_RolledExtraTryBall()
        {
            CancellationToken ct = new CancellationToken();
            var gameSettings = Options.Create(new GameSettings() { InitialBalance = 200, TryPrice = 10, WinPrice = 20 });
            var bagServiceMock = new Mock<IBagService>();
            var shufflerMock = new Mock<IShuffler>();
            bagServiceMock.Setup(_ => _.CreateBag()).Returns(new BagModel(shufflerMock.Object));
            bagServiceMock.Setup(_ => _.DrawBall(It.IsAny<BagModel>(), ct)).Returns(Task.FromResult(new BallModel(BallTypes.ExtraTry)));
            var gameService = new GameService(bagServiceMock.Object, gameSettings);
            var res = await gameService.Play(ct);
            bagServiceMock.Verify(_ => _.CreateBag(), Times.Once);
            bagServiceMock.Verify(_ => _.DrawBall(It.IsAny<BagModel>(), ct), Times.Once);
            Assert.IsFalse(res.Win);
            Assert.IsFalse(res.IsRoundCompleted);
        }
    }
}