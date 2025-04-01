using FinanceAPI.Endpoints;
using Scalar.AspNetCore;
using Serilog;
using System.Globalization;

namespace FinanceAPI.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication ConfigureApplication(this WebApplication app)
    {
        #region

        app.UseSerilogRequestLogging();

        #endregion

        #region API Configuration

        app.UseHttpsRedirection();

        #endregion

        #region Scalar

        var textInfo = CultureInfo.CurrentCulture.TextInfo;

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference(options =>
            {
                options.WithTitle($"Finance API - {textInfo.ToTitleCase(app.Environment.EnvironmentName)} - V1");
            });
        }

        #endregion

        #region Cors

        app.UseCors();

        #endregion Cors

        #region Exception Handling

        app.UseExceptionHandler();

        #endregion

        #region Authorization Policy

        app.UseAuthorization();

        #endregion

        #region MinimalApi

        app.MapAuthEndpoints();
        app.MapEmployeeEndpoints();
        app.MapReferencesEndpoints();

        #endregion 

        return app;
    }
}
