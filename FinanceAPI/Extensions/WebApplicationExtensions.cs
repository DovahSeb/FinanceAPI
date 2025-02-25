using FinanceAPI.Endpoints;
using Scalar.AspNetCore;
using System.Globalization;

namespace FinanceAPI.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication ConfigureApplication(this WebApplication app)
    {
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


        #region MinimalApi

        app.MapReferencesEndpoints();

        #endregion 

        return app;
    }
}
