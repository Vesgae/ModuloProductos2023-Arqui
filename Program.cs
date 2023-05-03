using Microsoft.EntityFrameworkCore;
using ModuloProductos_v1.Entities;
using Microsoft.Extensions.Configuration;
using System.Configuration;

internal class Program
{
    private const string stringConnection = "server=localhost;port=3315;user=root;password=root;database=dbserviciosproductosvehiculos";

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        IServiceCollection serviceCollection = builder.Services.AddDbContext<DbserviciosproductosvehiculosContext>(
            options =>
        { options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("11.1.0-mariadb")); });
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        /*builder.Services.AddDbContext<DbserviciosproductosvehiculosContext>(options => options.UseSqlServer(
builde.Configuration.GetConnectionString("DefaultConnection")
));*/
        var app = builder.Build();
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
}