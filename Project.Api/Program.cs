using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Project.Finance.Application;
using Project.Finance.Infrastructure;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.FinanceDependencyInjection();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHealthChecks()
    .AddCheck("SimpleHealthCheck", () => HealthCheckResult.Healthy("The application is running."));

var connectionString = new[] { "PGHOST", "PGPORT", "PGDATABASE", "PGUSER", "PGPASSWORD" }
    .Select(env => Environment.GetEnvironmentVariable(env))
    .Any(string.IsNullOrEmpty)
    ? builder.Configuration.GetConnectionString("DefaultConnection")
    : $"Host={Environment.GetEnvironmentVariable("PGHOST")};Port={Environment.GetEnvironmentVariable("PGPORT")};Database={Environment.GetEnvironmentVariable("PGDATABASE")};Username={Environment.GetEnvironmentVariable("PGUSER")};Password={Environment.GetEnvironmentVariable("PGPASSWORD")};";

builder.Services.AddDbContext<FinanceDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT no formato: Bearer {seu token}"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });

    opt.UseInlineDefinitionsForEnums();
    opt.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Finance Web API",
        Version = "0.3.1",
        Contact = new OpenApiContact
        {
            Email = "wanrod.dev@gmail.com",
            Name = "WanRod"
        }
    });
});

builder.Services.AddMvc().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = c =>
    {
        var errors = c.ModelState.Values
            .Where(v => v.Errors.Count > 0)
            .SelectMany(v => v.Errors)
            .Select(v => v.ErrorMessage)
            .ToList();

        return new BadRequestObjectResult(new
        {
            status_code = StatusCodes.Status400BadRequest,
            message = errors.Select(e => new { error = e }).ToList(),
            date_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        });
    };
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]!)),
            ClockSkew = TimeSpan.Zero
        };
    });

var app = builder.Build();

app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = async (context, report) =>
    {
        context.Response.ContentType = "application/json";
        var response = new
        {
            status = report.Status.ToString(),
            checks = report.Entries.Select(e => new { name = e.Key, status = e.Value.Status.ToString() }),
            duration = report.TotalDuration.TotalMilliseconds
        };
        await context.Response.WriteAsJsonAsync(response);
    }
});

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        context.Response.ContentType = "application/json";

        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

        if (contextFeature is not null)
        {
            var errorResponse = new
            {
                status_code = context.Response.StatusCode,
                message = contextFeature.Error.Message,
                date_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            await context.Response.WriteAsJsonAsync(errorResponse);
        }
    });
});

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Run($"http://0.0.0.0:{port}");
