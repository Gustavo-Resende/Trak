using System.Reflection;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Extensions.Logging;
using Trak.API.Middleware;
using Trak.Infrastructure;
using Trak.Infrastructure.Data.PostgreSQL;
using Trak.Infrastructure.Data.SQLServer;

var logger = Log.Logger = new LoggerConfiguration()
  .Enrich.FromLogContext()
  .WriteTo.Console()
  .CreateLogger();

logger.Information("Starting host");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));
var microsoftLogger = new SerilogLoggerFactory(logger)
    .CreateLogger<Program>();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Valhalla Example API",
        Version = "v1",
        Description = "Valhallaaaaaa"
    });

    // Adiciona suporte a coment�rios XML
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

// Configure services
builder.Services.AddInfrastructureServices(microsoftLogger, builder.Configuration);
builder.Services.AddUseCasesServices(microsoftLogger);

// Isso aqui nao deveria ta aqui, mas esta, f�
builder.Services.AddHostedService<AppDbInitializerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Theatrical Players API v1");
    });
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();
app.Run();

public class AppDbInitializerService(IServiceProvider _serviceProvider) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<PgSqlDbContext>();
            dbContext.InitializeDatabase();
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
