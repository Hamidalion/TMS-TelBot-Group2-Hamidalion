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
        public IEnumerable<BankCurrencies> sortByBestUSDBuyRate(IEnumerable<BankCurrencies> bankCurrencies)
        {
            return bankCurrencies.OrderByDescending(b => b.USDBuyRate);
        }

        public IEnumerable<BankCurrencies> sortByBesEURBuyRate(IEnumerable<BankCurrencies> bankCurrencies)
        {
            return bankCurrencies.OrderByDescending(b => b.EURBuyRate);
        }

        public IEnumerable<BankCurrencies> sortByBesRUBBuyRate(IEnumerable<BankCurrencies> bankCurrencies)
        {
            return bankCurrencies.OrderByDescending(b => b.RUBBuyRate);
        }
        public IEnumerable<BankCurrencies> sortByBestUSDSaleRate(IEnumerable<BankCurrencies> bankCurrencies)
        {
            return bankCurrencies.OrderBy(b => b.USDSaleRate);
        }

        public IEnumerable<BankCurrencies> sortByBestEURSaleRate(IEnumerable<BankCurrencies> bankCurrencies)
        {
            return bankCurrencies.OrderBy(b => b.EURSaleRate);
        }

        public IEnumerable<BankCurrencies> sortByBesRUBSaleRate(IEnumerable<BankCurrencies> bankCurrencies)
        {
            return bankCurrencies.OrderBy(b => b.RUBSaleRate);
        }

    }
}
