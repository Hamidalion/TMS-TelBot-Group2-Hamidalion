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
            BankCurrencies bankCurrencies = new BankCurrencies();
            bankCurrencies.BankName = elements[0];
            double val;
            double.TryParse(elements[1], NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat, out val);
            bankCurrencies.USDBuyRate = val;
            double.TryParse(elements[2], NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat, out val);
            bankCurrencies.USDSaleRate = val;
            double.TryParse(elements[3], NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat, out val);
            bankCurrencies.EURBuyRate = val;
            double.TryParse(elements[4], NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat, out val);
            bankCurrencies.EURSaleRate = val;
            double.TryParse(elements[5], NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat, out val);
            bankCurrencies.RUBBuyRate = val;
            double.TryParse(elements[6], NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat, out val);
            bankCurrencies.RUBSaleRate = val;
            double.TryParse(elements[7], NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat, out val);
            bankCurrencies.EURToUSDBuyRate = val;
            double.TryParse(elements[8], NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat, out val);
            bankCurrencies.EURToUSDSaleRate = val;
            return bankCurrencies;
        }

        public override string ToString()
        {
            return string.Format($"{BankName,-30}\n{USDBuyRate,-10}{USDSaleRate,-10}{EURBuyRate,-10}{EURSaleRate,-10}" +
                $"{RUBBuyRate,-10}{RUBSaleRate,-10}{EURToUSDBuyRate,-10}{EURToUSDSaleRate,-10}");
        }
    }
}