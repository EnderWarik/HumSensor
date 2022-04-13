
namespace HumSensorAnalise
{
    public class Startup
    {
       

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<PortConnections>();


           // services.AddSingleton<ApplicationContext>();//должен ли быть конект одним экземпляром?

            services.AddHostedService(provider => { return provider.GetService<PortConnections>(); });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();
            app.UseCors();

          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action}/{id?}");
                //.endpoints.MapDefaultControllerRoute();
                //endpoints.MapControllers();

            });
        }

    }
}
