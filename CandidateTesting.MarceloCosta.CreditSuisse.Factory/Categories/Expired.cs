using CandidateTesting.MarceloCosta.CreditSuisse.Factory.Categories.Interfaces;
using CandidateTesting.MarceloCosta.CreditSuisse.Factory.Trades.Interfaces;

namespace CandidateTesting.MarceloCosta.CreditSuisse.Factory.Categories
{
  public class Expired : ICategory
  {
    public string Name => "EXPIRED";

    public bool EvaluateRisk(ITrade trade)
    {
      return trade.NextPaymentDate.Subtract(trade.ReferenceDate).Days < -30;
    }

  }
}