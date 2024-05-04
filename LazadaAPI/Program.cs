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

//Sign Repository 
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();


//Sign Dbcontext and Connect string
builder.Services.AddDbContext<LazadaApiDbContext>(option =>
{
    option.UseSqlServer(
        builder.Configuration.GetConnectionString("LazadaConnectionString"))
        .LogTo(Console.WriteLine);
});

//Add authorize identity 

// builder.Services.AddDefaultIdentity<User>(options => 
// options.SignIn.RequireConfirmedAccount = true)
//     .AddEntityFrameworkStores<LazadaApiDbContext>();

builder.Services.AddIdentity<ApplicationUser , ApplicationRole>()
.AddEntityFrameworkStores<LazadaApiDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddAuthorization();

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

