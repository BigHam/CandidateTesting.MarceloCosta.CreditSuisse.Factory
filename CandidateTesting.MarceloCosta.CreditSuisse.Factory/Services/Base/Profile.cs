using System.Collections.Generic;
using CandidateTesting.MarceloCosta.CreditSuisse.Factory.Categories.Interfaces;

namespace CandidateTesting.MarceloCosta.CreditSuisse.Factory.Services.Base
{
  public abstract class Profile
  {
    public abstract string Name { get; }
    public List<ICategory> ProfileCategories = new();
  }
}