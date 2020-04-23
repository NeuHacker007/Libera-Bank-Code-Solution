using System;
using System.Collections.Generic;
using Libera_Bank_Code_Solution.Models;
using Libera_Bank_Code_Solution.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Libera_Bank_Code_Solution
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<ITill>(new TillClass() { Till = new List<Coin>()
                {
                    new Coin() {CoinType = CoinType.Quarter, NumOfCoin = 1, Value = 0.25M},
                    new Coin() {CoinType = CoinType.Dime, NumOfCoin = 2, Value = 0.1M},
                    new Coin() {CoinType = CoinType.Nickel, NumOfCoin = 4, Value = 0.05M},
                    new Coin() {CoinType = CoinType.Penny, NumOfCoin = 5, Value = 0.01M}
                }
            }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
