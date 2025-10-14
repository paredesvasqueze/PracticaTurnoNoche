using Data;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Registro de repositorios y servicios para Producto
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoService, ProductoServiceDb>();

// Registro de repositorios y servicios para Docentes
builder.Services.AddScoped<IDocentesRepository, DocentesRepository>();
builder.Services.AddScoped<IDocentesService, DocentesServiceDb>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Agrega soporte para archivos estáticos (css, js, imágenes...)

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
