using KAI_bank_bot.Helpers;
using KAI_bank_bot.Interfaces;
using KAI_bank_bot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
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
        public async Task<List<Rate>> GetRateByNbrbOnDate(Message message , ITelegramBotClient client)
        {
            IRequestService requestService = new RequestService();
            List<Rate> rates = new List<Rate>();
            var usCulture = new System.Globalization.CultureInfo("ru-RU");
            await client.SendTextMessageAsync(message.Chat.Id, "Format: " + usCulture.DateTimeFormat.ShortDatePattern);
            Message messagewithDate = new Message();
            if (DateTime.TryParse(messagewithDate.Text, usCulture.DateTimeFormat, System.Globalization.DateTimeStyles.None, out DateTime userDate))
                await client.SendTextMessageAsync(message.Chat.Id ,"Valid date entered:" + userDate.ToShortDateString());
            else
                await client.SendTextMessageAsync(message.Chat.Id , "Invalid date specified!");
            if (userDate <= DateTime.Today)
            {
                var eurrate = await requestService.GetRateByDateAsync(CurrencyCode.EUR.ToString(), userDate);
                var rubrate = await requestService.GetRateByDateAsync(CurrencyCode.RUB.ToString(), userDate);
                var usdrate = await requestService.GetRateByDateAsync(CurrencyCode.USD.ToString(), userDate);
                rates.Add(eurrate);
                rates.Add(rubrate);
                rates.Add(usdrate);
                return rates;
            }
            return null;
        }

    }
}
