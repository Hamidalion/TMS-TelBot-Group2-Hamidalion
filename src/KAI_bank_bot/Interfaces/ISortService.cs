using KAI_bank_bot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KAI_bank_bot.Interfaces
{
    interface ISortService
    {
        List<BankCurrencies> sortByBestUSDBuyRate(List<BankCurrencies> bankCurrencies);

        List<BankCurrencies> sortByBesEURBuyRate(List<BankCurrencies> bankCurrencies);

        List<BankCurrencies> sortByBesRUBBuyRate(List<BankCurrencies> bankCurrencies);

        List<BankCurrencies> sortByBestUSDSaleRate(List<BankCurrencies> bankCurrencies);

        List<BankCurrencies> sortByBestEURSaleRate(List<BankCurrencies> bankCurrencies);

        List<BankCurrencies> sortByBesRUBSaleRate(List<BankCurrencies> bankCurrencies);

    }
}
