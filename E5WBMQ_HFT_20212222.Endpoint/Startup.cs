using E5WBMQ_HFT_2021222.Repository.GenericRepository;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;
using E5WBMQ_HFT_2021222.Models;
using E5WBMQ_HFT_2021222.Repository.Data;
using E5WBMQ_HFT_2021222.Logic.Logics;
using E5WBMQ_HFT_2021222.Repository.ModelRepositories;

namespace MovieDbApp.Endpoint
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
            services.AddTransient<WorldOfAllGamesDbContext>();

            services.AddTransient<IRepository<VideoGames>, VideoGamesRepository>();
            services.AddTransient<IRepository<Genres>, GenresRepository>();
            services.AddTransient<IRepository<Publishers>, PublishersRepository>();
            

            services.AddTransient<IVideoGamesLogic, VideoGamesLogic>();
            services.AddTransient<IGenresLogic, GenresLogic>();
            services.AddTransient<IPublishersLogic, PublishersLogic>();
            

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "E5WBMQ_HFT_20212222.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "E5WBMQ_HFT_20212222.Endpoint v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { Msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
