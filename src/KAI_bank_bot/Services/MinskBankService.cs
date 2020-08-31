using KAI_bank_bot.Interfaces;
using KAI_bank_bot.Models;
using KAI_bank_bot.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAI_bank_bot.Services
{
    public class MinskBankService
    {
        public async Task<List<BankCurrencies>> GetMinskRates()
        {
            IMyFinParsingService myFinParsingService = new MyFinParsingService();
            List<BankCurrencies> bankCurrencies = (List<BankCurrencies>)await myFinParsingService.Parse();
            return bankCurrencies;
        }
    }
}
