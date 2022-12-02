using Application.ApiBE;
using Application.Extensions;
using Infrastructure.Context;
using MediatR;
using Microsoft.AspNetCore.Localization;
using Microsoft.OpenApi.Models;
using Polly;
using Polly.Extensions.Http;
using Server.Extensions;
using System.Globalization;
using System.Reflection;

namespace Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger APIBE", Version = "v1" });
        });
        
        builder.Services.AddServerSideBlazor();
        builder.Services.AddControllers();

        var retryPolicy = Policy<HttpResponseMessage>
            .Handle<HttpRequestException>()
            .OrTransientHttpStatusCode()
            .WaitAndRetryAsync(3, attempt => TimeSpan.FromMilliseconds(100 * Math.Pow(2, attempt)));
        builder.Services.AddOptions();
        builder.Services.AddApplicationLayer();
        builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

        builder.Services.AddTransient<ISymbolService, SymbolService>();
        builder.Services.AddDatabase(builder.Configuration);

        builder.Services.AddTransient<IApiBEDbContext, ApiBEDbContext>();
    
        builder.Services.AddAuthorization();

        builder.Services.AddSingleton(
            builder.Configuration.GetSection("SymbolConfig").Get<SymbolConfig>());

        var app = builder.Build();
        app.MapControllers();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseWebAssemblyDebugging();
        var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.AddExceptionHandling(loggerFactory);
            app.UseHsts();
        }

        app.UseHttpsRedirection(); 

        var defaultDateCulture = "en-US";
        var ci = new CultureInfo(defaultDateCulture);
        ci.NumberFormat.NumberDecimalSeparator = ".";
        ci.NumberFormat.CurrencyDecimalSeparator = ".";

        // Configure the Localization middleware
        app.UseRequestLocalization(new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture(ci),
            SupportedCultures = new List<CultureInfo>
            {
                ci,
            },
                    SupportedUICultures = new List<CultureInfo>
            {
                ci,
            }
        });

        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.UseRouting();

        //app.UseAuthentication();
        //app.UseAuthorization();
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });


        // app.MapHealthChecks("/healthcheck");
        app.MapRazorPages();
        app.MapFallbackToFile("index.html");


        app.Run();
    }
}