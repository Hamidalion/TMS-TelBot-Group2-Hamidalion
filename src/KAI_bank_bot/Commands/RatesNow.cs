using KAI_bank_bot.Interfaces;
using KAI_bank_bot.Resources;
using KAI_bank_bot.Services;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace KAI_bank_bot.Commands
{
    public class RatesNow : ITelegramCommand
    {
        public string Name { get; } = RatesToday.Name;

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            try
            {
                NbrbRates nbrbRates = new NbrbRates();
                var chatId = message.Chat.Id;
                var result = await nbrbRates.GetRateByNbrbOnToday();
                foreach (var rate in result)
                {
                    await client.SendTextMessageAsync(chatId, $"Имя валюты : {rate.Cur_Name} \n Курс валюты : {rate.Cur_OfficialRate} BYN\n Скейл валюты : {rate.Cur_Scale}  \n Дата : {rate.Date} \n \n");
                }
            }
            catch (Exception)
            {
                var chatId = message.Chat.Id;
                await client.SendTextMessageAsync(chatId, Exeptions.OtherExeption);
            }
           
        }
        /// <inheritdoc/>   
        public bool Contains(Message message)
        {
            if (message != null)
            {
                return message.Type == MessageType.Text && message.Text.Contains(Name);
            }
            return false;
        }
    }
}
