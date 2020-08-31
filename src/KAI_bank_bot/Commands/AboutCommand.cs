using KAI_bank_bot.Interfaces;
using System;
using KAI_bank_bot.Resources;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace KAI_bank_bot.Commands
{
    /// <inheritdoc cref="ITelegramCommand"/>
    public class AboutCommand : ITelegramCommand
    {
        /// <inheritdoc/>
        public string Name { get; } = About.Link;

        /// <inheritdoc/>
        public bool Contains(Message message) => message != null && message.Type == MessageType.Text && message.Text.Contains(Name);

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            try
            {
                await client.SendTextMessageAsync(message.Chat.Id, About.Message);
            }
            catch (Exception)
            {
                await client.SendTextMessageAsync(message.Chat.Id, Exceptions.OtherExсeption);
            }
        }
    }
}
