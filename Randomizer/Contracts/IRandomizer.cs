namespace LotterySimulator.Randomizer.Contracts
{
    /// <summary>
    /// Basic interface for various randomization strategies
    /// </summary>
    public interface IRandomizer
    {
        /// <summary>
        /// Method for generating random int number
        /// </summary>
        /// <param name="min">Min int range</param>
        /// <param name="max">Max int range</param>
        /// <param name="ct">Cancellation roken for async operations</param>
        /// <returns>Random integer value</returns>
        Task<int> RandomizeInt(int min, int max, CancellationToken ct);
    }
}
