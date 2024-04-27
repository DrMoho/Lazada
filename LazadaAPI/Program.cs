using Microsoft.EntityFrameworkCore;
using LazadaApi.Models.Entities;
using LazadaApi.IRepositories;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository, ProductRepository>();
//Add authorize identity 
builder.Services.AddAuthorization();


builder.Services.AddDbContext<LazadaApiDbContext>(option =>
{
    option.UseSqlServer(
        builder.Configuration.GetConnectionString("LazadaConnectionString"))
        .LogTo(Console.WriteLine);
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<LazadaApiDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Lazada API v1"); // Đặt tên ở đây
    });

}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();


await Data.CreateData(app);


app.Run();

