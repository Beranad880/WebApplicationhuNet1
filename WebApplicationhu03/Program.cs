using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApplicationhu03.Models;
using WebApplicationhu03.Repositories;

var builder = WebApplication.CreateBuilder(args);

// P�id�n� slu�eb
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "E-Shop API", Version = "v1" });
});

// P�ipojen� k datab�zi
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrace repository
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// **Z�klad pro mapov�n� API kontroler�**
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
