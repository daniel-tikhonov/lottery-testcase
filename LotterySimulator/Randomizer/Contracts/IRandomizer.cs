namespace LotterySimulator.Randomizer.Contracts
{
    public interface IRandomizer
    {
        Task<int> RandomizeInt(int min, int max, CancellationToken ct);
    }
}
