using Microsoft.AspNetCore.Localization;
using System.Globalization;
using System.Text.RegularExpressions;

var cultureInfo = new CultureInfo("pt-BR"); // Define a cultura para Português (Brasil)


var culture = new CultureInfo("pt-BR"); // Define a cultura para Português (Brasil)
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRequestLocalization(new RequestLocalizationOptions //tentativa de resolver o problema com casas decimais
{
    DefaultRequestCulture = new RequestCulture("pt-BR"), 
    SupportedCultures = new[] { culture },
    SupportedUICultures = new[] { culture }
});


app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}")
    .WithStaticAssets();


app.Run();
