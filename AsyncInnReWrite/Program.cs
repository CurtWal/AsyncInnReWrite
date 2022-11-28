using AsyncInnReWrite.Models.Interface;
using AsyncInnReWrite.Models.Service;
using Hotel.Data;
using Hotel.Models.Services;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IRoom, RoomService>();
builder.Services.AddTransient<IHotel, HotelService>();
builder.Services.AddTransient<IAmenity, AmenityService>();
builder.Services.AddDbContext<HotelDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AzureContext")));

//builder.Services.AddSwaggerDocument();
builder.Services.AddSwaggerDocument(config =>
{
    config.PostProcess = document =>
    {
        document.Info.Version = "v1";
        document.Info.Title = "Async Hotel API";
        document.Info.Description = "A simple  ASP.Net Core MVC web api";
        document.Info.TermsOfService = "None";
        document.Info.Contact = new NSwag.OpenApiContact
        {
            Name = "Curtrick",
            Email = "curtrickw@yahoo.com",
            Url = "https://yahoo.com",
        };
        document.Info.License = new NSwag.OpenApiLicense
        {
            Name = "Use under MIT",
            Url = "https://opensource.org/licenses/MIT",
        };
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseOpenApi();
app.UseSwaggerUi3();

app.Run();
