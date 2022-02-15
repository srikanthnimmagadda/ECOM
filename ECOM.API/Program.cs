using ECOM.Core.Interfaces;
using ECOM.Infrastructure.Data;
using ECOM.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EComDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EComConnection")));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
SeedDatabase();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


async void SeedDatabase()
{
    using (IServiceScope? scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var loggerFactory = services.GetRequiredService<ILoggerFactory>();
        try
        {
            var context = services.GetRequiredService<EComDbContext>();
            await context.Database.MigrateAsync();
            await EComDataSeed.SeedAsync(context, loggerFactory);
        }
        catch (Exception exception)
        {
            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogError(exception, "An error occurred during migration");
        }
    }
}