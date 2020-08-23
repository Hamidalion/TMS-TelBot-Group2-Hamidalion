using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KAI_bank_bot.Models;

namespace KAI_bank_bot.Interfaces
{
    /// <summary>
    /// Сервис для отправки запросов.
    /// </summary>
    public interface IRequestService
    {
      
        /// <summary>
        /// Получить курс валюты.
        /// </summary>
        /// <param name="code">Код валюты.</param>
        /// <returns>Курс валюты.</returns>
        Task<Rate> GetRateAsync(string code);

        /// <summary>
        /// Получить курс валюты на определенную дату (как расширение)
        /// </summary>
        /// <param name="code">Код валюты.</param>
        /// <param name="date">Дата.</param>
        /// <returns>Курс валюты.</returns>
        
        Task<Rate> GetRateByDateAsync(string code, DateTime date);
    }
}