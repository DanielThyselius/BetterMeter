using BetterMeter.Api.Endpoints;
using BetterMeter.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// Default mapping is /openapi/v1.json
builder.Services.AddOpenApi();

builder.Services.AddDbContext<BetterMeterDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<IDatabase, Database>();
builder.Services.AddScoped<IQuestionService, QuestionService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Add cookie authentication
builder.Services.AddAuthentication()
    .AddCookie(IdentityConstants.ApplicationScheme);
builder.Services.AddAuthorization();

builder.Services.AddIdentityCore<IdentityUser>()
    .AddEntityFrameworkStores<BetterMeterDbContext>()
    .AddApiEndpoints();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // Todo: consider scalar? https://youtu.be/Tx49o-5tkis?feature=shared
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
        options.DefaultModelsExpandDepth(-1);
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// Map all endpoints
app.MapEndpoints<Program>();
app.MapIdentityApi<IdentityUser>();

app.Run();

public partial class Program { }