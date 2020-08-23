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
        public async Task<StringBuilder> GetMinskRates()
        {
            IMyFinParsingService myFinParsingService = new MyFinParsingService();
            List<BankCurrencies> bankCurrencies = (List<BankCurrencies>)await myFinParsingService.Parse();
            StringBuilder botMessage = new StringBuilder(Banks.Message);
            botMessage.Append(Banks.TableHeader);
            foreach (var b in bankCurrencies)
            {
               var result = botMessage.Append(b.ToString() + "\n");
                return result;
            }
            return null;
        }
    }
}
