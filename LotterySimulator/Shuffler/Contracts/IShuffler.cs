using LotterySimulator.Settings;

namespace LotterySimulator.Shuffler.Contracts
{
    /// <summary>
    /// Basic interface for different shuffle algorithms
    /// </summary>
    public interface IShuffler
    {
        /// <summary>
        /// Method for shuffling elements in array
        /// </summary>
        /// <typeparam name="TModel">Type of the models in arr</typeparam>
        /// <param name="arr">Array that should be shuffled</param>
        /// <param name="options">Various shuffle options</param>
        /// <param name="ct">Cancellation token for async operation</param>
        /// <returns>Shuffled array</returns>
        Task<IEnumerable<TModel>> Shuffle<TModel>(IEnumerable<TModel> arr, ShuffleSettings options, CancellationToken ct);
    }
}
