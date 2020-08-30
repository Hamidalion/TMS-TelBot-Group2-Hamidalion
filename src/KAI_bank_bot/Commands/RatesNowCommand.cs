﻿using KAI_bank_bot.Interfaces;
using KAI_bank_bot.Resources;
using KAI_bank_bot.Services;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace KAI_bank_bot.Commands
{
    /// <inheritdoc cref="ITelegramCommand"/>
    public class RatesNowCommand : ITelegramCommand
    {
        public string Name { get; } = RatesNow.Link;

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
                    await client.SendTextMessageAsync(chatId,  $" {rate.Cur_Scale} {rate.Cur_Abbreviation}  =  {rate.Cur_OfficialRate} BYN\n\n");
                }
            }
            catch (Exception)
            {
                var chatId = message.Chat.Id;
                await client.SendTextMessageAsync(chatId, Exceptions.OtherExсeption);
            }
           
        }
        /// <inheritdoc/>   
        public bool Contains(Message message) => message != null && message.Type == MessageType.Text && message.Text.Contains(Name);
    }
}
