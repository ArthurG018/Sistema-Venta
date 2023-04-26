using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAppVentaDSI.Data;
using WebAppVentaDSI.Data.DataAcces;
using WebAppVentaDSI.Data.Interface;
using static WebAppVentaDSI.Data.ApplicationDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<Usuario>(options => options.SignIn.RequireConfirmedAccount = true)
    //se agrega los roles
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

//programar los perfiles para el Gerente
builder.Services.AddAuthorization(
    options => options.AddPolicy("AllowLayoutGerente",
    policy => policy.RequireRole("Gerente")));
//programar los perfiles para el Supervisor
builder.Services.AddAuthorization(
    options => options.AddPolicy("AllowLayoutSupervisor",
    policy => policy.RequireRole("Supervisor")));
//programar los perfiles para el Vendedor
builder.Services.AddAuthorization(
    options => options.AddPolicy("AllowLayoutVendedor",
    policy => policy.RequireRole("Vendedor")));
//PARA AMBOS ROLES (QUE PUEDEN HACER AMBOS GERENTE Y SUPERVISOR)
builder.Services.AddAuthorization(
    options => options.AddPolicy("AllowLayoutGerenteSupervisor",
    policy => policy.RequireRole("Gerente", "Supervisor")));
//PARA LOS TRES ROLES (QUE PUEDEN HACER AMBOS GERENTE, SUPERVISOR, VENDEDOR)
builder.Services.AddAuthorization(
    options => options.AddPolicy("AllowLayoutGerenteSupervisorVendedor",
    policy => policy.RequireRole("Gerente", "Supervisor","Vendedor")));



//SERVICIO PARA REALIZAR LA INYECCION DE DEPENDENCIAS
//                              interface          data acces
builder.Services.AddSingleton<IDACargoEmpleado, DACargoEmpleado>();
builder.Services.AddSingleton<IDACliente, DACliente>();
builder.Services.AddSingleton<IDAComprobante, DAComprobante>();
builder.Services.AddSingleton<IDADetalleComprobante, DADetalleComprobante>();
builder.Services.AddSingleton<IDADetalleTipoPago,DADetalleTipoPago>();
builder.Services.AddSingleton<IDAEmpleado,DAEmpleado>();
builder.Services.AddSingleton<IDAProducto,DAProducto>();
builder.Services.AddSingleton<IDATipoComprobante,DATipoComprobante>();
builder.Services.AddSingleton<IDATipoPago, DATipoPago>();
builder.Services.AddSingleton<IDAFamiliaProducto, DAFamiliaProducto>();
builder.Services.AddSingleton<IDAMarcaProducto, DAMarcaProducto>();
builder.Services.AddSingleton<IDADetalleEmpleado, DADetalleEmpleado>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
