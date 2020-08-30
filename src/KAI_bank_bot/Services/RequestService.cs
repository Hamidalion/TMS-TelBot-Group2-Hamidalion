using Flurl;
using Flurl.Http;
using System;
using System.Globalization;
using System.Threading.Tasks;
using KAI_bank_bot.Interfaces;
using KAI_bank_bot.Models;
using KAI_bank_bot.Resources;

namespace KAI_bank_bot.Services
{
    /// <inheritdoc cref="IRequestService"/>
    public class RequestService : IRequestService
    {
        /// <inheritdoc/>
        public async Task<Rate> GetRateAsync(string code)
        {
            try
            {
                var response = await Common.NbRBUrl
                    .AppendPathSegments("exrates", "rates", code)
                    .GetJsonAsync<Rate>();
                return response;
            }
            catch (FlurlHttpTimeoutException)
            {
                Console.WriteLine("Request timed out ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        /// <inheritdoc/>
        public async Task<Rate> GetRateByDateAsync(string code, DateTime date)
        {
            try
            {
                var response = await Common.NbRBUrl
                    .AppendPathSegments("exrates", "rates", code)
                    .SetQueryParam("ondate", date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
                    .GetJsonAsync<Rate>();
                return response;
            }
            catch (FlurlHttpTimeoutException)
            {
                Console.WriteLine("Request timed out ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
