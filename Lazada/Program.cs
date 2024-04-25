using Microsoft.EntityFrameworkCore;
using Lazada.Models.Entities;
using Lazada.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("LazadaIdentityDbContextConnection") ?? throw new InvalidOperationException("Connection string 'LazadaIdentityDbContextConnection' not found.");

builder.Services.AddDbContext<LazadaIdentityDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<LazadaIdentityDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
      app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapDefaultControllerRoute();







app.Run();



