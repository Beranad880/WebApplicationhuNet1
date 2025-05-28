using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApplicationhu03.Models;
using WebApplicationhu03.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Pøidání služeb
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "E-Shop API", Version = "v1" });
});

// Pøipojení k databázi
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

// **Základ pro mapování API kontrolerù**
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
