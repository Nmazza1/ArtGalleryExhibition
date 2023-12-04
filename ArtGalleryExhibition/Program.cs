using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ArtGalleryExhibition.Data;
using Auth0.AspNetCore.Authentication;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ArtGalleryExhibitionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ArtGalleryExhibitionContext") ?? throw new InvalidOperationException("Connection string 'ArtGalleryExhibitionContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"];
    options.ClientId = builder.Configuration["Auth0:ClientId"];
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
