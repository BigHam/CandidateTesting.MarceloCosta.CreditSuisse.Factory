using CandidateTesting.MarceloCosta.CreditSuisse.Factory.Helpers;
using CandidateTesting.MarceloCosta.CreditSuisse.Factory.Services;
using CandidateTesting.MarceloCosta.CreditSuisse.Factory.Services.Base;
using CandidateTesting.MarceloCosta.CreditSuisse.Factory.Trades;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateTesting.MarceloCosta.CreditSuisse.Factory
{
  class Program
  {
    static async Task Main(string[] args)
    {
      var servicesCollection = new ServiceCollection();
      ConfigureServices(servicesCollection);
      var serviceProvider = servicesCollection.BuildServiceProvider();

      try
      {
        if (!InputArgs(args))
          return;

        var pathIn = args[0];
        var pathOut = args[1];

        var myFactory = serviceProvider.GetService<ProcessTradeFactory>();
        await myFactory?.ExecuteAsync("Teste01", pathIn, pathOut);

        ConsoleColorHelpers.WriteLine("The classification was carried out successfully!", ConsoleColor.DarkGray);
        ConsoleColorHelpers.Write("The resulting file is at: ", ConsoleColor.DarkGray);
        ConsoleColorHelpers.WriteLine($"{pathOut}", ConsoleColor.Yellow);
      }
      catch (ArgumentException e)
      {
        ArgumentErrorError(e);
      }
      catch (Exception e)
      {
        GenericError(e);
      }
      Console.Read();
    }


    public static void ConfigureServices(IServiceCollection services)
    {
      services.AddSingleton<InputBase, FileInputService<Trade>>();
      services.AddSingleton<OutputBase, FileOutputService>();
      services.AddSingleton<ProcessTradeFactory>();
    }


    private static bool InputArgs(string[] args)
    {
      if (args.Any() || args.Length == 2) return true;
      ConsoleColorHelpers.Write("How to use: ", ConsoleColor.White);
      ConsoleColorHelpers.Write("  creditsuisse ", ConsoleColor.Green);
      ConsoleColorHelpers.Write("[profile-name] ", ConsoleColor.Green);
      ConsoleColorHelpers.Write("[url-input] ", ConsoleColor.Green);
      ConsoleColorHelpers.WriteLine("[file-to-output] ", ConsoleColor.Green);

      ConsoleColorHelpers.Write("Sample: ", ConsoleColor.White);
      ConsoleColorHelpers.WriteLine("creditsuisse Teste01 './AppData/InputSample.txt' './AppData/OutputSample.txt'", ConsoleColor.White);
      return false;
    }

    private static void ArgumentErrorError(ArgumentException e)
    {
      ConsoleColorHelpers.Write("Arguments error occurred: ", ConsoleColor.DarkRed);
      ConsoleColorHelpers.Write(e.Message, ConsoleColor.DarkRed);
      Environment.ExitCode = 0;
    }

    private static void GenericError(Exception e)
    {
      ConsoleColorHelpers.Write("An error occurred while processing the classification. Original message: ", ConsoleColor.DarkRed);
      ConsoleColorHelpers.Write(e.Message, ConsoleColor.DarkRed);
      Environment.ExitCode = 0;
    }

  }


}
