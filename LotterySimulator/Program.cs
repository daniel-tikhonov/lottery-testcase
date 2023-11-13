// See https://aka.ms/new-console-template for more information
using LotterySimulator.Exceptions;
using LotterySimulator.Game.Contracts;
using LotterySimulator.Game.Services;
using LotterySimulator.Randomizer.Contracts;
using LotterySimulator.Randomizer.Services;
using LotterySimulator.Settings;
using LotterySimulator.Shuffler.Contracts;
using LotterySimulator.Shuffler.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        //Set up basic services
        var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);
        IConfiguration config = builder.Build();
        var serviceCollection = new ServiceCollection()
            .AddTransient<IShuffler, FisherYatesShuffler>()
            .AddTransient<IRandomizer, LocalRandomizer>()
            .AddTransient<IBagService, BagService>()
            .AddTransient<ISimulatorService, SimulatorService>()
            .AddTransient<IGameService, GameService>();

        serviceCollection.Configure<BagSettings>(config.GetSection("Bag"));
        serviceCollection.Configure<GameSettings>(config.GetSection("Game"));
        serviceCollection.Configure<ShuffleSettings>(config.GetSection("Shuffler"));
        var serviceProvider = serviceCollection.BuildServiceProvider();
        

        var gameService = serviceProvider.GetRequiredService<IGameService>();
        var simulatorService = serviceProvider.GetRequiredService<ISimulatorService>();
        var ct = new CancellationToken();
        while (true)
        {
            Console.WriteLine($"Lottery simulator. Your balance: {gameService.Balance}. P - play round. S - start simulation. C - clean. E - exit.");
            var key = Console.ReadKey();
            Console.WriteLine();
            switch (key.KeyChar)
            {
                case 'p':
                    {
                        try
                        {
                            var result = gameService.Play(ct).Result;
                            if (!result.IsRoundCompleted)
                            {
                                Console.WriteLine("You have free extra roll!");
                            }
                            else if (result.Win)
                            {
                                Console.WriteLine("Congrats you won!");
                            }
                            else
                            {
                                Console.WriteLine("Sorry you lost :(");
                            }
                        } catch(OutOfBalanceException e)
                        {
                            Console.WriteLine("Not enough money for roll ask admin to add more.");
                        }
                        continue;
                    }
                case 's':
                    {
                        Console.WriteLine("Enter rounds count for simulation...");
                        var number = Console.ReadLine();
                        if (int.TryParse(number, out var roundsCount))
                        {
                            var response = simulatorService.Simulate(roundsCount, ct).Result;
                            Console.WriteLine($"RTP = {response.Rtp}");
                        } else
                        {
                            Console.WriteLine("Invalid input...");
                        }
                        continue;
                    }
                case 'c':
                    {
                        Console.Clear();
                        continue;
                    }
                case 'e':
                    {
                        Console.WriteLine("Exiting app...");
                        break;
                    }
            }
        }
    }
}