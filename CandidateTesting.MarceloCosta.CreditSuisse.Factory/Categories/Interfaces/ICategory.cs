using CandidateTesting.MarceloCosta.CreditSuisse.Factory.Trades.Interfaces;

namespace CandidateTesting.MarceloCosta.CreditSuisse.Factory.Categories.Interfaces
{
  public interface ICategory
  {
    string Name { get; }
    public bool EvaluateRisk(ITrade trade);
  }
}