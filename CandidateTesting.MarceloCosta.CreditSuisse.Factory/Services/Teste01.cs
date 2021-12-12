using CandidateTesting.MarceloCosta.CreditSuisse.Factory.Categories;
using CandidateTesting.MarceloCosta.CreditSuisse.Factory.Services.Base;

namespace CandidateTesting.MarceloCosta.CreditSuisse.Factory.Services
{
  public class Teste01 : Profile
  {
    public override string Name => "Perfil 01 de Teste";

    public Teste01()
    {
      ProfileCategories.Add(new Expired());
      ProfileCategories.Add(new HighRisk());
    }
  }
}