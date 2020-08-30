using KAI_bank_bot.Models;
using System.Collections.Generic;

namespace KAI_bank_bot.Interfaces
{
    /// <summary>
    /// Service for sorting Banks rates
    /// </summary>
    interface ISortService
    {
        /// <summary>
        /// Sort by best USD Buy Rate
        /// </summary>
        /// <param name="bankCurrencies">List for sorting</param>
        /// <returns>Sorted list</returns>
        List<BankCurrencies> SortByBestUSDBuyRate(List<BankCurrencies> bankCurrencies);

        /// <summary>
        /// Sort by best EUR Buy Rate
        /// </summary>
        /// <param name="bankCurrencies">List for sorting</param>
        /// <returns>Sorted list</returns>
        List<BankCurrencies> SortByBesEURBuyRate(List<BankCurrencies> bankCurrencies);

        /// <summary>
        /// Sort by best RUB Buy Rate
        /// </summary>
        /// <param name="bankCurrencies">List for sorting</param>
        /// <returns>Sorted list</returns>
        List<BankCurrencies> SortByBesRUBBuyRate(List<BankCurrencies> bankCurrencies);

        /// <summary>
        /// Sort by best USD Sale Rate
        /// </summary>
        /// <param name="bankCurrencies">List for sorting</param>
        /// <returns>Sorted list</returns>
        List<BankCurrencies> SortByBestUSDSaleRate(List<BankCurrencies> bankCurrencies);

        /// <summary>
        /// Sort by best EUR Sale Rate
        /// </summary>
        /// <param name="bankCurrencies">List for sorting</param>
        /// <returns>Sorted list</returns>
        List<BankCurrencies> SortByBestEURSaleRate(List<BankCurrencies> bankCurrencies);

        /// <summary>
        /// Sort by best RUB Sale Rate
        /// </summary>
        /// <param name="bankCurrencies">List for sorting</param>
        /// <returns>Sorted list</returns>
        List<BankCurrencies> SortByBesRUBSaleRate(List<BankCurrencies> bankCurrencies);
    }
}
