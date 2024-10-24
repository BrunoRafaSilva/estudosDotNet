using identifyOs.Interfaces;
using identifyOs.Views;
using Microsoft.AspNetCore.Mvc;
using Supabase;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL") ?? string.Empty;
var DATABASE_KEY = Environment.GetEnvironmentVariable("DATABASE_KEY") ?? string.Empty;

builder.Services.AddScoped<Supabase.Client>(_ =>
    new Supabase.Client(
        DATABASE_URL,
        DATABASE_KEY,
        new SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = true,
        }
    )
);

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

await app.RunAsync();

