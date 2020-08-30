using KAI_bank_bot.Interfaces;
using KAI_bank_bot.Models;
using KAI_bank_bot.Resources;
using KAI_bank_bot.Services;
using System;
using System.Collections.Generic;
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
                IMyFinParsingService myFinParsingService = new MyFinParsingService();
                var chatId = message.Chat.Id;
                var result = (List<BankCurrencies>)await myFinParsingService.Parse();
                var parametrs = message.Text.ToLower().Split(" ");

                if (parametrs.Length == 3)
                {
                    ISortService sortService = new SortService();

                    switch (parametrs[1])
                    {
                        case "usd":
                            {
                                switch (parametrs[2])
                                {
                                    case "buy":
                                        {
                                            result = sortService.SortByBestUSDBuyRate(result);
                                            break;
                                        }
                                    case "sale":
                                        {
                                            result = sortService.SortByBestUSDSaleRate(result);
                                            break;
                                        }
                                }
                                break;
                            }

                        case "eur":
                            {
                                switch (parametrs[2])
                                {
                                    case "buy":
                                        {
                                            result = sortService.SortByBesEURBuyRate(result);
                                            break;
                                        }
                                    case "sale":
                                        {
                                            result = sortService.SortByBestEURSaleRate(result);
                                            break;
                                        }
                                }
                                break;
                            }

                        case "rub":
                            {
                                switch (parametrs[2])
                                {
                                    case "buy":
                                        {
                                            result = sortService.SortByBesRUBBuyRate(result);
                                            break;
                                        }
                                    case "sale":
                                        {
                                            result = sortService.SortByBesRUBSaleRate(result);
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                }

                foreach (var bank in result)
                {
                    await client.SendTextMessageAsync(chatId, $"\U0001F6A9{ bank.BankName} \U0001F6A9\n\U0001F4B0 Покупка / Продажа \U0001F4B0\n\U000020AC 1 EUR: " +
                        $"{bank.EURBuyRate} BYN / {bank.EURSaleRate} BYN \U000020AC\n" +
                        $"\U000020BD 100 RUB: {bank.EURBuyRate} BYN / {bank.RUBSaleRate} BYN \U000020BD\n\U00000024 USD: {bank.USDBuyRate} BYN / {bank.USDSaleRate} BYN \U00000024\n");
                }
            }
            catch (Exception e)
            {
                var chatId = message.Chat.Id;
                await client.SendTextMessageAsync(chatId, Exceptions.OtherExсeption);
                Console.WriteLine(e.Message);
            }
        }

        /// <inheritdoc/>
        public bool Contains(Message message) => message != null && message.Type == MessageType.Text && message.Text.Contains(Name);
    }
}
