using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using OAuthOidc.Data.DbContexts;
using OAuthOidc.ExtensionMethods;
using OAuthOidc.Validators;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllersWithViews().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(cfg =>
    {
        cfg.ReturnUrlParameter = "returnUrl";
    });

services.AddDbContext<ConfigurationDbContext>(cfg =>
{
    cfg.UseSqlServer(configuration.GetConnectionString("Default"), x =>
    {
        x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    });
});

services.AddDbContext<UsersDbContext>(cfg =>
{
    cfg.UseSqlServer(configuration.GetConnectionString("Default"), x =>
    {
        x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    });
});

services.AddDbContext<PersistedGrantsDbContext>(cfg =>
{
    cfg.UseSqlServer(configuration.GetConnectionString("Default"), x =>
    {
        x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    });
});

services.RegisterTransientServices();
services.RegisterScopedServices();
services.RegisterSingletonServices();

var app = builder.Build();

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();

public delegate IGrantValidator ValidationResolver(string key);