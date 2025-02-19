namespace FinanceAPI.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication ConfigureApplication(this WebApplication app)
    {
        #region API Configuration

        app.UseHttpsRedirection();

        #endregion

        return app;
    }
}
