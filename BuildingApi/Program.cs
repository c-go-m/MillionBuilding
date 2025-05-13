using BuildingApi.Config;
using Utilities.Utilities;

var builder = WebApplication.CreateBuilder(args);

try
{
    builder.Services.AddControllers();
    builder.Services.AddDocumentation();
    builder.Services.AddInvalidModelMiddleware();
    builder.Services.AddCorsCustom();
    builder.Services.AddAutentication();
    builder.Services.AddDatabase();
    builder.Services.AddDependency();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseDocumentation();
    }

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.UseCors(ConstantsConfig.ConfigurationCorsPolicy);

    await app.RunAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"Application startup failed: {ex.Message}");
}
