using KAI_bank_bot.Resources;
using KAI_bank_bot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace KAI_bank_bot.Commands
{
    public class GetCurrencyRateByNbrbByDate
    {
        public string Name { get; } = NbrbRateByDate.Name;

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            NbrbRates nbrbRate = new NbrbRates();
            var chatId = message.Chat.Id;          
            var result = await nbrbRate.GetRateByNbrbOnDate(message,client);
            foreach (var rate in result)
            {
                await client.SendTextMessageAsync(chatId, $"Имя валюты : {rate.Cur_Name} \n Курс валюты : {rate.Cur_OfficialRate} \n Скейл валюты : {rate.Cur_Scale}  \n Дата : {rate.Date} \n \n");
            }
        }
        /// <inheritdoc/>   
        public bool Contains(Message message) => message.Type == MessageType.Text && message.Text.Contains(Name);
    }
}
