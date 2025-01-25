using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using TaskManagementv2.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor(); // Add Blazor Server services
//builder.Services.AddScoped<CustomAuthenticationStateProvider>();
//builder.Services.AddAuthorizationCore();

// Add DbContext before building the app
builder.Services.AddDbContext<MyAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Ensure static files are served

app.UseRouting();

app.UseAuthorization();

app.MapBlazorHub(); // Map Blazor Hub for Blazor Server
app.MapRazorPages();

app.Run();
