using KAI_bank_bot.Interfaces;
using KAI_bank_bot.Models;
using KAI_bank_bot.Resources;
using KAI_bank_bot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace KAI_bank_bot.Commands
{
    /// <inheritdoc cref="ITelegramCommand"/>
    public class BanksCommand : ITelegramCommand
    {
        /// <inheritdoc/>
        public string Name { get; } = Banks.Link;

        /// <inheritdoc/>
        public bool Contains(Message message) => message.Type == MessageType.Text && message.Text.Contains(Name);

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            MinskBankService minskBankService = new MinskBankService();
            var chatId = message.Chat.Id;
            var result = minskBankService.GetMinskRates();
            await client.SendTextMessageAsync(chatId, result.ToString(), ParseMode.Html);
        }
    }
}
