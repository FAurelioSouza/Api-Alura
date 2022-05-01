using UsuariosApi.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UsuariosApi.Services;

namespace UsuariosApi
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
            Console.WriteLine("URL Conn: " + builder.Configuration.GetSection("Data").GetConnectionString("UsuarioConnection"));
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
            builder.Services.AddDbContext<UserDbContext>(opts => opts.UseSqlServer(Configuration.GetSection("Data").GetConnectionString("UsuarioConnection")));
            builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>().AddEntityFrameworkStores<UserDbContext>();
            builder.Services.AddScoped<CadastroService, CadastroService>();
            builder.Services.AddScoped<LoginService, LoginService>();
            // passando as definições para cada controler com seu respectivo Service.
            //builder.Services.AddTransient<DbContextFactory>();
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
