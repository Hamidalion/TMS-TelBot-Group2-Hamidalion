using System;
using System.Linq;
using System.Threading.Tasks;
using KAI_bank_bot.Interfaces;
using KAI_bank_bot.Services;

namespace KAI_bank_bot.Service
{
    /// <summary>
    /// Действия программы.
    /// </summary>
    public static class ProgrammActions
    {
        private static readonly IRequestService requestService = new RequestService();
       
        /// <summary>
        /// Показать список всех валют.
        /// </summary>
        public static async Task ShowAllCurrenciesAsync()
        {
            var data = await requestService.GetAllCurrenciesAsync();
            foreach (var currency in data)
            {
                Console.WriteLine($"ID of currency:{ currency.Cur_ID} Name of currency:{currency.Cur_Name}");
            }
        }

        /// <summary>
        /// Показать валюту.
        /// </summary>
        public static async Task ShowCurrencyAsync()
        {
            Console.WriteLine("Enter Id of currency");
            var userinput = Console.ReadLine();

            if (!string.IsNullOrEmpty(userinput))
            {
                var data = await requestService.GetCurrencyAsync(userinput);
                if (data != null)
                {
                    Console.WriteLine($"{ data.Cur_Name} Scale of currency:{data.Cur_Scale}");
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                }
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }

        /// <summary>
        /// Показать список всех курсов валют.
        /// </summary>
        public static async Task ShowAllRatesToBynAsync()
        {
            var data = await requestService.GetAllRatesAsync();
            foreach (var rate in data)
            {
                Console.WriteLine($"{rate.Cur_Scale} {rate.Cur_Name} Rate to currency:{rate.Cur_OfficialRate} Date:{rate.Date}");
            }
        }

        /// <summary>
        /// Показать курс бел. руб. к определенной валюте.
        /// </summary>
        public static async Task ShowBynRateAsync()
        {
            Console.WriteLine("Enter Id of currency");
            var userinput = Console.ReadLine();
            if (!string.IsNullOrEmpty(userinput))
            {
                var data = await requestService.GetRateAsync(userinput);
                if (data != null)
                {
                    Console.WriteLine($"{data.Cur_Scale} {data.Cur_Name} Rate to currency:{data.Cur_OfficialRate} Date:{data.Date}");

                   
                    int.TryParse(Console.ReadLine(), out int decision);
                    switch (decision)
                    {
                        case 1:
                            {
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("No data recorded");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Incorrect input");
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                }
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }

        /// <summary>
        /// Показать курс бел. руб. к определенной валюте и определенной дате.
        /// </summary>
        /// <returns></returns>
        public static async Task ShowBynRateToDateAsync()
        {
            Console.WriteLine("Enter Id of currency");
            var userinput = Console.ReadLine();
            if (!string.IsNullOrEmpty(userinput))
            {
                var data = await requestService.GetCurrencyAsync(userinput);
                if (data != null)
                {
                    Console.WriteLine($"Choosed currency: { data.Cur_Name}");
                    var usCulture = new System.Globalization.CultureInfo("ru-RU");
                    Console.WriteLine("Format: " + usCulture.DateTimeFormat.ShortDatePattern);
                    string dateString = Console.ReadLine();
                    if (DateTime.TryParse(dateString, usCulture.DateTimeFormat, System.Globalization.DateTimeStyles.None, out DateTime userDate))
                        Console.WriteLine("Valid date entered:" + userDate.ToShortDateString());
                    else
                        Console.WriteLine("Invalid date specified!");
                    if (!string.IsNullOrEmpty(userinput) && (userDate <= DateTime.Today))
                    {
                        var dataRate = await requestService.GetRateByDateAsync(userinput, userDate);
                        if (dataRate != null)
                        {
                            Console.WriteLine($"{dataRate.Cur_Scale} {dataRate.Cur_Name} Rate to currency:{dataRate.Cur_OfficialRate} Date:{dataRate.Date}");
                            Console.WriteLine("Do you wanna write this data to file?\n1:Write to file\n2:Do not write");
                            int.TryParse(Console.ReadLine(), out int decision);
                            switch (decision)
                            {
                                case 1:
                                    {
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("No data recorded");
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Incorrect input");
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Incorrect data");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                }
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }
        /// <summary>
        /// Показать список всех курсов бел. руб. к определенной дате.
        /// </summary>
        public static async Task ShowAllBynRatesToDateAsync()
        {
            var usCulture = new System.Globalization.CultureInfo("ru-RU");
            Console.WriteLine("Please specify a date. Format: " + usCulture.DateTimeFormat.ShortDatePattern);
            string dateString = Console.ReadLine();
            if (DateTime.TryParse(dateString, usCulture.DateTimeFormat, System.Globalization.DateTimeStyles.None, out DateTime userDate))
                Console.WriteLine("Valid date entered:" + userDate.ToShortDateString());
            else
                Console.WriteLine("Invalid date specified!");
        }
    }
}
