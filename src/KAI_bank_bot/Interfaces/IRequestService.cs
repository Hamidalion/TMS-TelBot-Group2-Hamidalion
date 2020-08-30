using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KAI_bank_bot.Models;

namespace KAI_bank_bot.Interfaces
{
    /// <summary>
    /// Service for sending requests 
    /// </summary>
    public interface IRequestService
    {
        /// <summary>
        /// Get currency rate for today
        /// </summary>
        /// <param name="code">Currency code</param>
        /// <returns>Currency rate</returns>
        Task<Rate> GetRateAsync(string code);

        /// <summary>
        /// Get currency rate on date 
        /// </summary>
        /// <param name="code">Currency code</param>
        /// <param name="date">Date</param>
        /// <returns>Currency rate</returns>
        Task<Rate> GetRateByDateAsync(string code, DateTime date);
    }
}