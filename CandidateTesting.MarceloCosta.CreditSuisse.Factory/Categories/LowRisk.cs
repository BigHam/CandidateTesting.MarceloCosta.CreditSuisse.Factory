using CandidateTesting.MarceloCosta.CreditSuisse.Factory.Categories.Interfaces;
using CandidateTesting.MarceloCosta.CreditSuisse.Factory.Trades.Interfaces;

namespace CandidateTesting.MarceloCosta.CreditSuisse.Factory.Categories
{
  public class LowRisk : ICategory
  {
    public string Name => "LOWRISK";

    public bool EvaluateRisk(ITrade trade)
    {
      return true;
    }

  }
}