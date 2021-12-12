using CandidateTesting.MarceloCosta.CreditSuisse.Factory.Categories.Interfaces;
using CandidateTesting.MarceloCosta.CreditSuisse.Factory.Trades.Enums;
using CandidateTesting.MarceloCosta.CreditSuisse.Factory.Trades.Interfaces;

namespace CandidateTesting.MarceloCosta.CreditSuisse.Factory.Categories
{
  public class HighRisk : ICategory
  {
    public string Name => "HIGHRISK";

    public bool EvaluateRisk(ITrade trade)
    {
      return trade.Value > 1000000 && trade.ClientSector == EnumClienteSector.Private;
    }
  }
}