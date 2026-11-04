var builder = WebApplication.CreateBuilder(args);

// Registra los servicios de MVC (controladores + vistas)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Permite servir archivos de wwwroot (css, js, imágenes)
app.UseStaticFiles();

app.UseRouting();

// Ruta por defecto: /Peces/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Peces}/{action=Index}/{id?}");

app.Run();
