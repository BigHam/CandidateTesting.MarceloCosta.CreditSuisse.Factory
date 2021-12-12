using System;
using CandidateTesting.MarceloCosta.CreditSuisse.Factory.Categories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CandidateTesting.MarceloCosta.CreditSuisse.Factory.Trades.Interfaces;

namespace CandidateTesting.MarceloCosta.CreditSuisse.Factory.Services.Base
{
  // Creator
  public abstract class ProcessTradeFactoryMethod
  {
    private readonly InputBase _inputBase;
    private readonly OutputBase _outputBase;
    private Profile _profileSelected;

    protected ProcessTradeFactoryMethod(InputBase inputBase, OutputBase outputBase)
    {
      _inputBase = inputBase;
      _outputBase = outputBase;
    }

    protected void LoadProfile(string perfil)
    {
      var profileType = Assembly.GetExecutingAssembly().GetTypes().Single(c =>
          c.BaseType == typeof(Profile) && c.GetConstructor(Type.EmptyTypes) != null && c.Name == perfil);
      _profileSelected = (Profile)Activator.CreateInstance(profileType);
    }

    protected async Task<List<ITrade>> LoadProtifolioAsync(string pathFileInput)
    {
      return await _inputBase.LoadFileAsync(pathFileInput);
    }

    protected async Task SaveProtifolioResult(List<string> outputList, string pathFileOutput)
    {
      await _outputBase.SaveFileAsync(outputList, pathFileOutput);
    }

    private string InteractWithCategories(ITrade trade)
    {
      foreach (var categoryInstance in _profileSelected.ProfileCategories)
      {
        if (categoryInstance.EvaluateRisk(trade))
        {
          return categoryInstance.Name;
        }
      }
      return "NOTCATEGORIZED";
    }

    protected List<string> InteractWithTrades(List<ITrade> portifolio)
    {
      return portifolio.Select(InteractWithCategories).ToList();
    }

    public abstract Task ExecuteAsync(string perfil, string pathIn, string pathOut);
  }
}