using System;
using CandidateTesting.MarceloCosta.CreditSuisse.Factory.Trades.Enums;
using CandidateTesting.MarceloCosta.CreditSuisse.Factory.Trades.Interfaces;

namespace CandidateTesting.MarceloCosta.CreditSuisse.Factory.Trades
{
  public class Trade : ITrade
  {
    DateTime ITrade.ReferenceDate { get; set; }
    double ITrade.Value { get; set; }
    EnumClienteSector ITrade.ClientSector { get; set; }
    DateTime ITrade.NextPaymentDate { get; set; }
  }
}