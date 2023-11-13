using LotterySimulator.Settings;

namespace LotterySimulator.Shuffler.Contracts
{
    public interface IShuffler
    {
        Task<IEnumerable<TModel>> Shuffle<TModel>(IEnumerable<TModel> arr, ShuffleSettings options, CancellationToken ct);
    }
}
