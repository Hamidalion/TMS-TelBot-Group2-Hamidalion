using KAI_bank_bot.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KAI_bank_bot.Interfaces
{
    public interface IMyFinParsingService
    {
        /// <summary>
        /// Parse site.
        /// </summary>
        /// <returns>Collection of banks</returns>
        Task<IEnumerable<BankCurrencies>> Parse();
    }
}
