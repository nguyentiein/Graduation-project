using dotenv.net;
using FPM.API;
using FPM.API.Controllers.Config;
using FPM.API.Controllers.Middlewares;
using FPM.Core.Database;
using FPM.Extensions;
using FPM.Resourses;
using FPM.Resourses.DTOs.Log.Request;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Serilog;
using System;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateBootstrapLogger();
Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);
    DotEnv.Load(options: new DotEnvOptions(probeForEnv: true));

    var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    // Add services to the container.
    var configBuilder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
        .AddEnvironmentVariables();
    IConfigurationRoot configuration = configBuilder.Build();
    //Log.Information("Connecting: " + configuration.GetConnectionString("Mydatabase"));
    builder.Configuration.AddJsonFile("responsemessage.json", optional: false, reloadOnChange: true);

    // Sử dụng Serilog
    builder.Host.UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration));

    #region Add services to the container.
    // Gán giá trị cho Global    
    Global.ConnectionString = configuration.GetConnectionString("Mydatabase");
    
    Global.Version = builder.Configuration.GetValue<string>("Information:Version");

    // Gán giá trị cho phần JwtConfig
    builder.Configuration.GetSection(nameof(JwtConfig)).Get<JwtConfig>();

    // Gán giá trị cho phần Log-option
    builder.Configuration.GetSection(nameof(RequestResponseLoggerOption)).Get<RequestResponseLoggerOption>();

    // Gán giá trị cho phần smtp
    builder.Configuration.GetSection(nameof(SmtpConfig)).Get<SmtpConfig>();

    //add DBContext
    builder.Services.AddDbContext<FPMContext>(options => 
        options.UseMySql(Global.ConnectionString,ServerVersion.AutoDetect(Global.ConnectionString)).EnableSensitiveDataLogging()
    );

    builder.Services.AddHttpContextAccessor();
   

    builder.Services.AddControllers(opt =>
    {
        opt.ApplyProfile(); 
        // Add custom cache profile

    }).ConfigureApiBehaviorOptions(options =>
    {
        // Adds a custom error response factory when Model-State is invalid
        options.InvalidModelStateResponseFactory = InvalidResponseFactory.ProduceErrorResponse;
    });

    // Mapping data from response-message.json
    builder.Services.Configure<ResponseMessage>(builder.Configuration.GetSection(nameof(ResponseMessage)));


  

    builder.Services.AddResponseCaching();
    builder.Services.AddCustomizeSwagger();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDependencyInjection(builder.Configuration);
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
    });

    #endregion

    #region Configure the HTTP request pipeline.
    var app = builder.Build();

    if (app.Environment.IsDevelopment() || app.Environment.IsProduction() || app.Environment.IsStaging())
    {
        if (app.Environment.IsDevelopment())
            Global.IsDebug = true;

        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseSerilogRequestLogging();
    app.UseMiddleware<ErrorHandlerMiddleware>();
    app.UseMiddleware<JwtMiddleware>();
    //deny access to document folder in root
    app.Use(async (context, next) =>
    {
        // Check if the request is for a file in the "upload/documents" folder
        if (context.Request.Path.StartsWithSegments("/upload/documents"))
        {
            // Get the relative file path from the URL
            var filePath = context.Request.Path.Value;

            // Redirect to the DocumentController's GetFile action with the filePath as a query parameter
            var redirectUrl = $"/api/v1/document/GetFile?fileName={filePath}";

            context.Response.Redirect(redirectUrl);
            return; // Stop processing further middleware
        }

        await next(); // Continue with the next middleware if path doesn't match
    });
    
    //app.UseMiddleware<RequestResponseLoggerMiddleware>();
    if (app.Environment.IsProduction())
    {
       //app.UseHttpsRedirection();
    }

    app.UseCors("AllowAll");
    //app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseResponseCaching();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
    #endregion
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}