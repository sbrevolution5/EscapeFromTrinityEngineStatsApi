using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StatisticsApi.Context;
using StatisticsApi.Data;
using StatisticsApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StatisticsDbContext>(options => options.UseNpgsql(DataUtility.GetConnectionString(builder.Configuration)));
builder.Services.AddScoped<IDtoConverterService, DtoConverterService>();
builder.Services.AddScoped<IFetchDataService, FetchDataService>();
builder.Services.AddScoped<IDashboardDataService, DashboardDataService>();
builder.Services.AddScoped<ICardPickRateService, CardPickRateService>();
builder.Services.AddScoped<IBattleFetchService, BattleFetchService>();
builder.Services.AddScoped<ICharacterFetchService, CharacterFetchService>();
builder.Services.Configure<JsonOptions>(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StatisticsDbContext>();
    db.Database.Migrate();   // <-- This applies migrations
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
