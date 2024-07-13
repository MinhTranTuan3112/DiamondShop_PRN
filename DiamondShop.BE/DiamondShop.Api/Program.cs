using DiamondShop.Api.Extensions;
using DiamondShop.Api.Middlewares;
using DiamondShop.BusinessLogic.Extensions;
using DiamondShop.DataAccess.Extensions;
using Serilog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
builder.Services.AddApiDependencies(configuration)
                .AddBusinessLogicDependencies()
                .AddDataAccessDependencies();

builder.Services.AddControllers().AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
//Add serilog
builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"J:\developer\studying\PRN221\DiamondShop_PRN\DiamondShop.BE\DiamondShop.Api\diamondshop-253ae-firebase-adminsdk-1l4ve-7b18a585f3.json");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();