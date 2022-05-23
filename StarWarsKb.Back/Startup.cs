using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StarWarsKb.Back.Model;
using StarWarsKb.Back.Model.POCO;
using StarWarsKb.Infrastructure.Model;
using StarWarsKb.Infrastructure.Services;

namespace StarWarsKb.Back
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
            services.AddTransient<IBaseRepository<Character>, CharactersRepository>();
            services.AddTransient<IParamService, ParamService>();
            services.AddDbContext<ApplicationDbContext>();
            services.AddTransient<IBaseRepository<Starship>, StarshipsRepository>();
            services.AddTransient<IBaseRepository<Planet>, PlanetsRepository>();
            services.AddTransient<IReportGenerator, ReportGenerator>();
            services.AddTransient<IUpdateService, UpdateService>();
            services.AddTransient<IWebReader<CharacterPOCO>, WebCharacterPOCOReader>();
            services.AddTransient<IWebReader<StarshipPOCO>, WebStarshipPOCOReader>();
            services.AddTransient<IWebReader<PlanetPOCO>, WebPlanetPOCOReader>();
            services.AddTransient<ICharacterService, CharacterService>();
            services.AddTransient<IStarshipService, StarshipService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IBaseRepository<Starship>, StarshipsRepository>();
            services.AddTransient<IBaseRepository<Planet>, PlanetsRepository>();
            services.AddTransient<IBaseRepository<Character>, CharactersRepository>();
            services.AddTransient<IPlanetService, PlanetService>();
            services.AddTransient<IClearService, ClearService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}