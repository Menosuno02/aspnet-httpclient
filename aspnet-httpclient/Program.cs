using aspnet_httpclient.Data;
using aspnet_httpclient.Helpers;
using aspnet_httpclient.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

string connectionString = builder.Configuration.GetConnectionString("SqlServer");
builder.Services.AddTransient<RepositoryRestaurantes>();
builder.Services.AddDbContext<RestaurantesContext>
    (options => options.UseSqlServer(connectionString));

string googleApiKey = builder.Configuration.GetValue<string>("GoogleApiKey");
builder.Services.AddTransient<HelperGoogleApiDirections>
    (h => new HelperGoogleApiDirections(googleApiKey, h.GetRequiredService<IHttpClientFactory>()));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();