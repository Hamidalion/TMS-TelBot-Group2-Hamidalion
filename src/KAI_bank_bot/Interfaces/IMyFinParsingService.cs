using KAI_bank_bot.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KAI_bank_bot.Interfaces
{
    /// <summary>
    /// MyFin parsing service
    /// </summary>
    public interface IMyFinParsingService
    {
        /// <summary>
        /// Parse MyFin
        /// </summary>
        /// <returns>Collection of banks currencies</returns>
        Task<IEnumerable<BankCurrencies>> Parse();
    }
}
