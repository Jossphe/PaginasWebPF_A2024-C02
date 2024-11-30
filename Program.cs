using Microsoft.EntityFrameworkCore;
using ReciclajeApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Registrar el repositorio para la inyección de dependencias
builder.Services.AddScoped<IEmpresaReciclajeRepository, EmpresaReciclajeRepository>();

// Configuración del servicio de Testimonio Repository
builder.Services.AddScoped<ITestimonioRepository, TestimonioRepository>();

// Configuración del servicio de Buenas Prácticas Repository
builder.Services.AddScoped<IBuenaPracticaRepository, BuenaPracticaRepository>();

// Configuración de la conexión a la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar los servicios necesarios para MVC (controladores con vistas)
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
