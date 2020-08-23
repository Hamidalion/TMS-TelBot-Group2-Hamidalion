using KAI_bank_bot.Interfaces;
using KAI_bank_bot.Models;
using KAI_bank_bot.Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KAI_bank_bot.Services
{
    public class NbrbRates
    {
        public async Task<List<Rate>> GetRateByNbrbOnToday()
        {
            IRequestService requestService = new RequestService();
            List<Rate> rates = new List<Rate>();
            var eurrate = await requestService.GetRateAsync(Currencies.EUR);
            var rubrate = await requestService.GetRateAsync(Currencies.RUB);
            var usdrate = await requestService.GetRateAsync(Currencies.USD);
            rates.Add(eurrate);
            rates.Add(rubrate);
            rates.Add(usdrate);
            return rates;
        }
        public async Task<List<Rate>> GetRateByNbrbOnDate(DateTime userDate)
        {
            IRequestService requestService = new RequestService();
            List<Rate> rates = new List<Rate>();
            if (userDate <= DateTime.Today)
            {
                var eurrate = await requestService.GetRateByDateAsync(Currencies.EUR, userDate);
                var rubrate = await requestService.GetRateByDateAsync(Currencies.RUB, userDate);
                var usdrate = await requestService.GetRateByDateAsync(Currencies.USD, userDate);
                rates.Add(eurrate);
                rates.Add(rubrate);
                rates.Add(usdrate);
                return rates;
            }
            return null;
        }

    }
}
