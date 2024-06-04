using DiamondShop.Api.Extensions;
using DiamondShop.Api.Middlewares;
using DiamondShop.BusinessLogic.Extensions;
using DiamondShop.DataAccess.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
builder.Services.AddApiDependencies(configuration)
                .AddBusinessLogicDependencies()
                .AddDataAccessDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
