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
    /// <inheritdoc cref="ITelegramCommand"/>
    public class BanksCommand : ITelegramCommand
    {
        /// <inheritdoc/>
        public string Name { get; } = Banks.Link;

        /// <inheritdoc/>
        public async Task Execute(Message message, ITelegramBotClient client)
        {
            try
            {
                MinskBankService minskBankService = new MinskBankService();
                var chatId = message.Chat.Id;
                var result = await minskBankService.GetMinskRates();
                foreach (var bank in result)
                {
                    await client.SendTextMessageAsync(chatId, $"Имя банка: {bank.BankName}\nEUR:Продажа - {bank.EURSaleRate} EUR:Покупка - {bank.EURBuyRate}\n" +
                        $"USD:Продажа - {bank.USDSaleRate} USD:Покупка - {bank.USDBuyRate}\nRUB:Продажа - {bank.RUBSaleRate} RUB:Покупка - {bank.EURBuyRate}\n" +
                        $"EUR к USD:Продажа - {bank.EURToUSDSaleRate} EUR к USD:Покупка - {bank.EURToUSDBuyRate}\n");
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
            if(message != null)
            {
                return message.Type == MessageType.Text && message.Text.Contains(Name);
            }
            return false;
        }
    }
}
