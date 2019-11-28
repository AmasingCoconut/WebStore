using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebStore
{
    public class Startup
    {

        // основная инфраструктура приложения - 3 раздела: контроллеры, представления и модели
        public IConfiguration Configuration { get;  }
        public Startup(IConfiguration Config) { Configuration = Config; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes => 
            {
                routes.MapRoute(
                    name: "default", 
                    "{controller=Home}/{action=Index}/{id?}");
            });
            //app.UseMvcWithDefaultRoute(); // тоже самое, что написано вверху: произойдет такое же конфигурирование системы маршрутизации приложения
            //mvc терминальное по, ниже нельзя добавлять обработчики конвеера. 
            //Если добавить обработчик выше (app.run()), то конвеер не дойдет до системы mvc, потому что ысе запросы будут обрабатываться выше.
            // для системы mvc необходимо сконфигурировать маршруты

            //app.run(async (context) =>
            //{
            //    await context.response.writeasync(configuration["customdata"]);
            //});
        }
    }
}
