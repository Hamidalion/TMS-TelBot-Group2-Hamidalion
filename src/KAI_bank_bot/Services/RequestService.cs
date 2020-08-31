using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using KAI_bank_bot.Helpers;
using KAI_bank_bot.Interfaces;
using KAI_bank_bot.Models;

namespace KAI_bank_bot.Services
{
    /// <inheritdoc cref="IRequestService"/>
    public class RequestService : IRequestService
    {
        public async Task<Rate> GetRateAsync(string code)
        {
            try
            {
                var response = await Constants.UrlApi
                    .AppendPathSegments("exrates", "rates", code)
                    .GetJsonAsync<Rate>();

                return response;
            }
            catch (FlurlHttpTimeoutException)
            {
                Console.WriteLine("Request timed out ");
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }


        public async Task<Rate> GetRateByDateAsync(string code, DateTime date)
        {
            try
            {
                var response = await Constants.UrlApi
                    .AppendPathSegments("exrates", "rates", code)
                    .SetQueryParam("ondate", date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
                    .GetJsonAsync<Rate>();

                return response;
            }
            catch (FlurlHttpTimeoutException)
            {
                Console.WriteLine("Request timed out ");
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
