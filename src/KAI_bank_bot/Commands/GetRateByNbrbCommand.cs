using KAI_bank_bot.Interfaces;
using KAI_bank_bot.Resources;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace KAI_bank_bot.Commands
{
    /// <inheritdoc cref="ITelegramCommand"/>
    public class GetRateByNbrbCommand : ITelegramCommand
    {
        /// <inheritdoc/>
        public string Name { get; } = GetRateByNbrbCommand.Link;

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId, );
        }

        /// <inheritdoc/>
        public bool Contains(Message message) => message.Type == MessageType.Text && message.Text.Contains(Name);
    }
}