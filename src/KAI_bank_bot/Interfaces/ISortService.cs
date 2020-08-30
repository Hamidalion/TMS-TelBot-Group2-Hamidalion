using KAI_bank_bot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KAI_bank_bot.Interfaces
{
    interface ISortService
    {
         IEnumerable<BankCurrencies> sortByBestUSDBuyRate(IEnumerable<BankCurrencies> bankCurrencies);

         IEnumerable<BankCurrencies> sortByBesEURBuyRate(IEnumerable<BankCurrencies> bankCurrencies);

         IEnumerable<BankCurrencies> sortByBesRUBBuyRate(IEnumerable<BankCurrencies> bankCurrencies);

         IEnumerable<BankCurrencies> sortByBestUSDSaleRate(IEnumerable<BankCurrencies> bankCurrencies);

         IEnumerable<BankCurrencies> sortByBestEURSaleRate(IEnumerable<BankCurrencies> bankCurrencies);

         IEnumerable<BankCurrencies> sortByBesRUBSaleRate(IEnumerable<BankCurrencies> bankCurrencies);

    }
}
