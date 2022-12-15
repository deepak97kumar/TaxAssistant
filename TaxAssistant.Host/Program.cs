using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaxAssistant.Repository;
using TaxAssistant.Repository.Models;
using TaxAssistant.Calculator;

public static class Program
{
    private static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<TaxAssistantContext>(options =>
            options.UseSqlServer(config.GetConnectionString("TaxAssistant")));
        builder.Services.ConfigureServices(builder.Configuration);

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/error");
        }
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}