using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static WebAppVentaDSI.Data.ApplicationDbContext;

namespace WebAppVentaDSI.Data
{//No olvidar <Usuario> para que reciba al usuario y se migre(?)
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        //para mandar a la clase usuario
        public class Usuario : IdentityUser
        {
            public string Nombre { get; set; }
            public string Apellidos { get; set; }
            public string DNI { get; set; }
            public string Direccion { get; set; }
        }
        //metodo protegido
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //se llama a la entidad usuario y al entitytypebuilder un tipo de entidad
            builder.Entity<Usuario>(EntityTypeBuilder =>
            {
                EntityTypeBuilder.ToTable("AspNetUsers");
                EntityTypeBuilder.Property(u => u.UserName)
                .HasMaxLength(100)
                .HasDefaultValue(0);
                EntityTypeBuilder.Property(u => u.Nombre)
                .HasMaxLength(80);
                EntityTypeBuilder.Property(u => u.Apellidos)
                .HasMaxLength(80);
                EntityTypeBuilder.Property(u => u.DNI)
                .HasMaxLength(8);
                EntityTypeBuilder.Property(u => u.Direccion)
                .HasMaxLength(100);

            });
        }

        //CREAMOS UN CONSTRUCTOR VACIO
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //CREAR LAS TABLAS EN LA BD
        public virtual DbSet<WebAppVentaDSI.Models.Estado> Estado { get; set; }
        public virtual DbSet<WebAppVentaDSI.Models.FamiliaProducto> FamiliaProducto { get; set; }
        public virtual DbSet<WebAppVentaDSI.Models.MarcaProducto> MarcaProducto { get; set; }
        public virtual DbSet<WebAppVentaDSI.Models.Cliente> Cliente { get; set; }
        public virtual DbSet<WebAppVentaDSI.Models.CargoEmpleado> CargoEmpleado { get; set; }
        public virtual DbSet<WebAppVentaDSI.Models.TipoComprobante> TipoComprobante { get; set; }
        public virtual DbSet<WebAppVentaDSI.Models.TipoPago> TipoPago { get; set; }
        public virtual DbSet<WebAppVentaDSI.Models.Empleado> Empleado { get; set; }
        public virtual DbSet<WebAppVentaDSI.Models.Producto> Producto { get; set; }
        public virtual DbSet<WebAppVentaDSI.Models.Comprobante> Comprobante { get; set; }
        public virtual DbSet<WebAppVentaDSI.Models.DetalleTipoPago> DetalleTipoPago { get; set; }
        public virtual DbSet<WebAppVentaDSI.Models.DetalleComprobante> DetalleComprobante { get; set; }
        public virtual DbSet<WebAppVentaDSI.Models.DetalleEmpleado> DetalleEmpleado { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-UJ3V5PV;Database=DBVentas-PGarcia;" +
                "User id=sa;password=123;MultipleActiveResultSets=True");
        }
    }
}