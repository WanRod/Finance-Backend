using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Project.Finance.Application;
using Project.Finance.Infrastructure;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add dependency injection
builder.Services.FinanceDependencyInjection();

// Config connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add DbContext to the container services
builder.Services.AddDbContext<FinanceDbContext>(options =>
    options.UseNpgsql(connectionString));

var jsonSerializerOptions = new JsonSerializerOptions
{
    Converters =
    {
        new JsonStringEnumConverter()
    }
};

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    //options.EnableAnnotations();
    options.UseInlineDefinitionsForEnums();

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Finance Web API",
        Version = "0.1.0",
        Contact = new OpenApiContact
        {
            Email = "wanrod.dev@gmail.com",
            Name = "Developed by WanRod",
        }
    });
});

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
