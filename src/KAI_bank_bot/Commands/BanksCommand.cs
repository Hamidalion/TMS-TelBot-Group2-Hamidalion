using KAI_bank_bot.Interfaces;
using KAI_bank_bot.Models;
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
                var result = (List<BankCurrencies>) await myFinParsingService.Parse();

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
                                            result = sortService.sortByBestUSDBuyRate(result);
                                            break;
                                        }
                                    case "sale":
                                        {
                                        result = sortService.sortByBestUSDSaleRate(result);
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
                                            result = sortService.sortByBesEURBuyRate(result);
                                            break;
                                        }
                                    case "sale":
                                        {
                                            result = sortService.sortByBestEURSaleRate(result);
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
                                            result = sortService.sortByBesRUBBuyRate(result);
                                            break;
                                        }
                                    case "sale":
                                        {
                                            result = sortService.sortByBesRUBSaleRate(result);
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                }

                foreach (var bank in result)
                {
                    await client.SendTextMessageAsync(chatId, $"{bank.BankName}\nПокупка/Продажа\n1 EUR: {bank.EURBuyRate} BYN / {bank.EURSaleRate} BYN \n" +
                        $"100 RUB: {bank.EURBuyRate} BYN / {bank.RUBSaleRate} BYN \n1 USD: {bank.USDBuyRate} BYN / {bank.USDSaleRate} BYN \n");
                }
            }
            catch (Exception e)
            {
                var chatId = message.Chat.Id;
                await client.SendTextMessageAsync(chatId, Exeptions.OtherExeption);
                Console.WriteLine(e.Message);
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
