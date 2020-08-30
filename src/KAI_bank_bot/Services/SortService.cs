using KAI_bank_bot.Interfaces;
using KAI_bank_bot.Models;
using System.Collections.Generic;
using System.Linq;

namespace KAI_bank_bot.Services
{
    /// <inheritdoc cref="ISortService"/>
    public class SortService : ISortService
    {
        /// <inheritdoc/>
        public List<BankCurrencies> SortByBestUSDBuyRate(List<BankCurrencies> bankCurrencies)
        {
            return bankCurrencies.OrderByDescending(b => b.USDBuyRate).ToList();
        }
        
        /// <inheritdoc/>
        public List<BankCurrencies> SortByBesEURBuyRate(List<BankCurrencies> bankCurrencies)
        {
            return bankCurrencies.OrderByDescending(b => b.EURBuyRate).ToList();
        }
        
        /// <inheritdoc/>
        public List<BankCurrencies> SortByBesRUBBuyRate(List<BankCurrencies> bankCurrencies)
        {
            return bankCurrencies.OrderByDescending(b => b.RUBBuyRate).ToList();
        }

        /// <inheritdoc/>
        public List<BankCurrencies> SortByBestUSDSaleRate(List<BankCurrencies> bankCurrencies)
        {
            return bankCurrencies.OrderBy(b => b.USDSaleRate).ToList();
        }

        /// <inheritdoc/>
        public List<BankCurrencies> SortByBestEURSaleRate(List<BankCurrencies> bankCurrencies)
        {
            return bankCurrencies.OrderBy(b => b.EURSaleRate).ToList();
        }

        /// <inheritdoc/>
        public List<BankCurrencies> SortByBesRUBSaleRate(List<BankCurrencies> bankCurrencies)
        {
            return bankCurrencies.OrderBy(b => b.RUBSaleRate).ToList();
        }
    }
}
