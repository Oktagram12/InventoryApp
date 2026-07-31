using Microsoft.EntityFrameworkCore;
using InventoryApp.Data;
using Scalar.AspNetCore;
using InventoryApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var maxRetries = 5;
    for (int retry = 0; retry < maxRetries; retry++)
    {
        try
        {
            db.Database.Migrate();
            Console.WriteLine("Veritabanı bağlantısı başarılı ve Migration uygulandı!");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Veritabanı henüz hazır değil. 2 saniye bekleniyor... (Deneme {retry + 1}/{maxRetries})");
            System.Threading.Thread.Sleep(2000);

            if (retry == maxRetries - 1)
                throw;
        }
    }
}

app.Run();