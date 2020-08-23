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
    public class RatesByDate : ITelegramCommand
    {
        public string Name { get; } = NbrbRateByDate.Name;

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            NbrbRates nbrbRate = new NbrbRates();
            var chatId = message.Chat.Id;
            var usCulture = new System.Globalization.CultureInfo("ru-RU");
            var usermessage = message.Text.Split(" ")[1];       
            if (DateTime.TryParse(usermessage, usCulture.DateTimeFormat, System.Globalization.DateTimeStyles.None, out DateTime userDate))
            {
                var result = await nbrbRate.GetRateByNbrbOnDate(userDate);
                foreach (var rate in result)
                {
                    await client.SendTextMessageAsync(chatId, $"Имя валюты : {rate.Cur_Name} \n {rate.Cur_Scale} {rate.Cur_Abbreviation} = {rate.Cur_OfficialRate} BYN \n \n");
                }
            }
            else
            {
                await client.SendTextMessageAsync(chatId, "Неверный формат даты");
            }
        }
        /// <inheritdoc/>   
        public bool Contains(Message message) => message.Type == MessageType.Text && message.Text.Contains(Name);
    }
}
