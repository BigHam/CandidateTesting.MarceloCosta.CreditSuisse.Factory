using System.Threading.Tasks;

namespace CandidateTesting.MarceloCosta.CreditSuisse.Factory.Services.Base
{
  // Concrete Creator
  public class ProcessTradeFactory : ProcessTradeFactoryMethod
  {
    public ProcessTradeFactory(InputBase inputBase, OutputBase outputBase) : base(inputBase, outputBase)
    {
    }

    public override async Task ExecuteAsync(string perfil, string pathIn, string pathOut)
    {
      var portifolio = await LoadProtifolioAsync(pathIn);
      
      LoadProfile(perfil);
      
      var outputList = InteractWithTrades(portifolio);
      
      await SaveProtifolioResult(outputList, pathOut);
    }

  }
}