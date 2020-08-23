using KAI_bank_bot.Helpers;
using KAI_bank_bot.Interfaces;
using KAI_bank_bot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace KAI_bank_bot.Services
{
    public class NbrbRates
    {
        public async Task<List<Rate>> GetRateByNbrbOnToday()
        {
            IRequestService requestService = new RequestService();
            List<Rate> rates = new List<Rate>();
            var eurrate = await requestService.GetRateAsync(CurrencyCode.EUR.ToString());
            var rubrate = await requestService.GetRateAsync(CurrencyCode.RUB.ToString());
            var usdrate = await requestService.GetRateAsync(CurrencyCode.USD.ToString());
            rates.Add(eurrate);
            rates.Add(rubrate);
            rates.Add(usdrate);
            return rates;
        }
    }
}
