using KAI_bank_bot.Interfaces;
using KAI_bank_bot.Models;
using KAI_bank_bot.Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KAI_bank_bot.Services
{
    /// <summary>
    /// Add rates from RequestService to list
    /// </summary>
    public class NbrbRates
    {
        
        /// <summary>
        /// Add rates on today to list
        /// </summary>
        /// <returns>List of rate odjects</returns>
        public async Task<List<Rate>> GetRateByNbrbOnToday()
        {
            IRequestService requestService = new RequestService();
            List<Rate> rates = new List<Rate>
            {
                await requestService.GetRateAsync(Currencies.EUR),
                await requestService.GetRateAsync(Currencies.RUB),
                await requestService.GetRateAsync(Currencies.USD)
            };
            return rates;
        }

        /// <summary>
        /// Add rates on same date to list
        /// </summary>
        /// <returns>List of rate odjects</returns>
        public async Task<List<Rate>> GetRateByNbrbOnDate(DateTime userDate)
        {
            IRequestService requestService = new RequestService();
            List<Rate> rates = new List<Rate>();
            if (userDate <= DateTime.Today)
            {
                rates.Add(await requestService.GetRateByDateAsync(Currencies.EUR, userDate));
                rates.Add(await requestService.GetRateByDateAsync(Currencies.RUB, userDate));
                rates.Add(await requestService.GetRateByDateAsync(Currencies.USD, userDate));
                return rates;
            }
            return null;
        }

    }
}
