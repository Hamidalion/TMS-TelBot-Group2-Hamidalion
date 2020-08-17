using KAI_bank_bot.Resources;
using System;
using System.Globalization;

namespace KAI_bank_bot.Models
{
    public class BankCurrencies
    {
        public string BankName { get; set; }
        public double USDBuyRate { get; set; }
        public double USDSaleRate { get; set; }
        public double EURBuyRate { get; set; }
        public double EURSaleRate { get; set; }
        public double RUBBuyRate { get; set; }
        public double RUBSaleRate { get; set; }
        public double EURToUSDBuyRate { get; set; }
        public double EURToUSDSaleRate { get; set; }

        public static BankCurrencies Parse(string s)
        {
            var elements = s.Split(Banks.Separator, StringSplitOptions.RemoveEmptyEntries);
            if (elements.Length != 9)
            {
                throw new ArgumentException();
            }
            BankCurrencies bankCurrencies = new BankCurrencies
            {
                BankName = elements[0],
                USDBuyRate = double.Parse(elements[1], CultureInfo.InvariantCulture.NumberFormat),
                USDSaleRate = double.Parse(elements[2], CultureInfo.InvariantCulture.NumberFormat),
                EURBuyRate = double.Parse(elements[3], CultureInfo.InvariantCulture.NumberFormat),
                EURSaleRate = double.Parse(elements[4], CultureInfo.InvariantCulture.NumberFormat),
                RUBBuyRate = double.Parse(elements[5], CultureInfo.InvariantCulture.NumberFormat),
                RUBSaleRate = double.Parse(elements[6], CultureInfo.InvariantCulture.NumberFormat),
                EURToUSDBuyRate = double.Parse(elements[7], CultureInfo.InvariantCulture.NumberFormat),
                EURToUSDSaleRate = double.Parse(elements[8], CultureInfo.InvariantCulture.NumberFormat)
            };
            return bankCurrencies;
        }

        public override string ToString()
        {
            return string.Format($"{BankName,-30}{USDBuyRate,-10}{USDSaleRate,-10}{EURBuyRate,-10}{EURSaleRate,-10}" +
                $"{RUBBuyRate,-10}{RUBSaleRate,-10}{EURToUSDBuyRate,-10}{EURToUSDSaleRate,-10}");
        }
    }
}