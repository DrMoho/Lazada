using Microsoft.EntityFrameworkCore;
using Lazada.Models;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<LazadaDbContext>(option =>
{
    option.UseSqlServer(
        builder.Configuration.GetConnectionString("LazadaConnectionString"))
        .LogTo(Console.WriteLine);
});


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

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapDefaultControllerRoute();

await Data.CreateData(app);

app.Run();
