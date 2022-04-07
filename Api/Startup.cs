using Api.Models;
using Api.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Api
{
    public static class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public static WebApplication InitializeApp(string [] args) 
        {
            var builder = WebApplication.CreateBuilder(args);
            Configuration = builder.Configuration;
            ConfigureService(builder);
            var app = builder.Build();
            //Configuration = app.Configuration;
            Console.WriteLine("URL Conn: " + builder.Configuration.GetSection("Data").GetConnectionString("FilmeConnection1"));
            Configure(app);
            return app;
        }

        private static void ConfigureService(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //string de conexão do banco
            //var connectionString = Configuration["Data:ConnectionStrings:FilmeConnection1"];
            builder.Services.AddDbContext<FilmeRepository>(opts => opts.UseLazyLoadingProxies().UseSqlServer(Configuration.GetSection("Data").GetConnectionString("FilmeConnection1")));
            builder.Services.AddTransient<DbContextFactory>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
        }

        private static void Configure (WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }
            app.MapControllers();
        }
    }
}
