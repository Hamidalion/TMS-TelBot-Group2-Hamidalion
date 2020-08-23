using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KAI_bank_bot.Extensions;
using KAI_bank_bot.Interfaces;
using KAI_bank_bot.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace KAI_bank_bot
{

    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        ///  онфигурации сервисов
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddScoped<ICommandService, CommandService>();
            services.AddTelegramBotClient(_configuration);
            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    });
        }

        public void Configure(IApplicationBuilder app)
        {
            //страница разработчика 
            app.UseDeveloperExceptionPage();

            //добавл€ем возможности маршрутизации
            app.UseRouting();

            // устанавливаем адреса, которые будут обрабатыватьс€
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();

                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
