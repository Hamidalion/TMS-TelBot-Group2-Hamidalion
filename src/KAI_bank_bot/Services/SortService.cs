using KAI_bank_bot.Interfaces;
using KAI_bank_bot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KAI_bank_bot.Services
{
    public class SortService : ISortService
    {
        public List<BankCurrencies> sortByBestUSDBuyRate(List<BankCurrencies> bankCurrencies)
        {
            return bankCurrencies.OrderByDescending(b => b.USDBuyRate).ToList();

        }

        public List<BankCurrencies> sortByBesEURBuyRate(List<BankCurrencies> bankCurrencies)
        {
            return bankCurrencies.OrderByDescending(b => b.EURBuyRate).ToList();
        }

        public List<BankCurrencies> sortByBesRUBBuyRate(List<BankCurrencies> bankCurrencies)
        {
            return bankCurrencies.OrderByDescending(b => b.RUBBuyRate).ToList();
        }
        public List<BankCurrencies> sortByBestUSDSaleRate(List<BankCurrencies> bankCurrencies)
        {
            return bankCurrencies.OrderBy(b => b.USDSaleRate).ToList();
        }

        public List<BankCurrencies> sortByBestEURSaleRate(List<BankCurrencies> bankCurrencies)
        {
            return bankCurrencies.OrderBy(b => b.EURSaleRate).ToList();
        }

        public List<BankCurrencies> sortByBesRUBSaleRate(List<BankCurrencies> bankCurrencies)
        {
            return bankCurrencies.OrderBy(b => b.RUBSaleRate).ToList();
        }

    }
}
