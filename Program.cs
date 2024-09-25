using Microsoft.EntityFrameworkCore;
using VidroRoto.Data;
using VidroRoto.Interfaces;
using VidroRoto.Repositories;

namespace VidroRoto
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
            builder.Services.AddScoped<IClientRepository, ClientRepository>();

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

            // Mapear Razor Pages y componentes de Blazor
            app.MapRazorPages();  // Mapear Razor Pages
            app.MapBlazorHub();    // Mapear la ruta del hub para Blazor Server

            app.Run();
        }
    }
}
