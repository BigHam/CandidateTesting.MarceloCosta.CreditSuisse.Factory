using CandidateTesting.MarceloCosta.CreditSuisse.Factory.Categories;
using CandidateTesting.MarceloCosta.CreditSuisse.Factory.Services.Base;

namespace CandidateTesting.MarceloCosta.CreditSuisse.Factory.Services
{
  public class Teste02 : Profile
  {
    public override string Name => "Perfil 02 de Teste";

    public Teste02()
    {
      ProfileCategories.Add(new Expired());
      ProfileCategories.Add(new HighRisk());
      ProfileCategories.Add(new MediumRisk());
    }
  }
}