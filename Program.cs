using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using VidroRoto.Data;
using VidroRoto.Interfaces;
using VidroRoto.Repositories;

namespace VidrioRoto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Agregar servicios al contenedor.
            builder.Services.AddRazorPages();  // Para Razor Pages
            builder.Services.AddServerSideBlazor();  // Para componentes interactivos

            // Configuración de la base de datos usando una conexión a Azure SQL
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("AzureSqlDatabase")));

            // Inyectar repositorios personalizados
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IVidrioRepository, VidrioRepository>();
            builder.Services.AddScoped<ICotizacionRepository, CotizacionRepository>();
            builder.Services.AddScoped<IHerrajeRepository, HerrajeRepository>();
            builder.Services.AddScoped<IMarcoRepository, MarcoRepository>();

            // Registrar los servicios de Swagger
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "VidroRoto API",
                    Version = "v1"
                });
            });

            var app = builder.Build();

            // Configuración del pipeline HTTP
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();  // Usar HSTS en producción
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            // Habilitar middleware de Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "VidroRoto API v1");
            });

           
            // Mapear Razor Pages y componentes de Blazor
            app.MapRazorPages();  // Mapear Razor Pages
            app.MapBlazorHub();    // Mapear la ruta del hub para Blazor Server

            app.Run();
        }
    }
}
