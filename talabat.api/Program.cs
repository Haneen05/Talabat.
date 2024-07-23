
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using talbat.core.Repositery;
using talbat.Repositrey;
using talbat.Repositrey.data.dataseeding;
using talbat.Repositrey.Service;

namespace talabat.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddDbContext<dbcontext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
            });
            builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GerericRepo<>));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Build the app
            var app = builder.Build();

            // Seed the database asynchronously
            SeedDatabaseAsync(app.Services).Wait();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }

        private static async Task SeedDatabaseAsync(IServiceProvider services)
        {
            var scope = services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<dbcontext>();
            var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();

            try
            {
                await StoreContextSeed.SeedAsync(dbContext);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occurred during database seeding.");
            }
        }

    }
}
