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
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
             var parseresult = ParseSite();
            await client.SendTextMessageAsync(chatId, parseresult.ToString(), ParseMode.Html);
        }

        /// <inheritdoc/>
        public bool Contains(Message message) => message.Type == MessageType.Text && message.Text.Contains(Name);

        /// <summary>
        /// Parse site and returns the processed result
        /// </summary>
        /// <returns>List of banks</returns>
        public async Task<StringBuilder> ParseSite()
        {
            IMyFinParsingService myFinParsingService = new MyFinParsingService();
            List<BankCurrencies> bankCurrencies = (List<BankCurrencies>)await myFinParsingService.Parse();
            StringBuilder botMessage = new StringBuilder(Banks.Message);
            botMessage.Append(Banks.TableHeader);
            foreach (var b in bankCurrencies)
            {
                botMessage.Append(b.ToString() + "\n");
            }
            return botMessage;
        }
    }
}
