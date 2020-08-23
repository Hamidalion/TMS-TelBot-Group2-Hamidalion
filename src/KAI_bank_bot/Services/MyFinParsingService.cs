using HtmlAgilityPack;
using KAI_bank_bot.Interfaces;
using KAI_bank_bot.Models;
using KAI_bank_bot.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KAI_bank_bot.Services
{
    public class MyFinParsingService : IMyFinParsingService
    {
        public async Task<IEnumerable<BankCurrencies>> Parse()
        {
            var banksCurrencies = new List<BankCurrencies>();
            var url = Banks.MyFinURL;
            var web = new HtmlWeb();
            HtmlDocument doc;
            try
            {
                doc = await web.LoadFromWebAsync(url);
                HtmlNodeCollection bankNodes = doc.DocumentNode.SelectNodes(Banks.Path);

                foreach (HtmlNode node in bankNodes.Skip(5))
                {
                    var info = node.ParentNode.ParentNode.Descendants("td");
                    string bankCurrenciesString = "";
                    foreach (var i in info)
                    {
                        bankCurrenciesString += i.InnerText.Trim();
                        bankCurrenciesString += Banks.Separator;
                    }
                    var bankCurrencies = BankCurrencies.Parse(bankCurrenciesString);
                    banksCurrencies.Add(bankCurrencies);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(Banks.ErrorMessage, e.Message);
            }
            return banksCurrencies;
        }
    }
}
