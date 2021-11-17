using ContentsApi.Code;
using ContentsApi.Models;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

const string CORSPOLICY = "ApiCorsPolicy";
const string ANGULARAPPURL = "https://localhost:4200";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy(CORSPOLICY, builder =>
{
    builder.WithOrigins(ANGULARAPPURL).AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = ApiKeyAuthenticationOptions.DefaultScheme;
    options.DefaultChallengeScheme = ApiKeyAuthenticationOptions.DefaultScheme;
})
.AddApiKeySupport(_ => { });

builder.Services.AddSingleton<IGetApiKeyQuery, InMemoryGetApiKeyQuery>();

var app = builder.Build();

app.UseCors(CORSPOLICY);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

//Senza minimal api
//app.MapControllers();

//Con minimal api
app.MapGet("/Contents", [Authorize] () =>
{
    try
    {
        return Results.Ok(JsonSerializer.Deserialize<Contents>(System.IO.File.ReadAllText("Data/library.json")));
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message, string.Empty, 500, "Internal server error", "https://httpstatuses.com/500");
    }
});

app.Run();