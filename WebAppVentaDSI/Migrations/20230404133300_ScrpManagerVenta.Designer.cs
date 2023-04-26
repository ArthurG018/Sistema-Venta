﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppVentaDSI.Data;

#nullable disable

namespace WebAppVentaDSI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230404133300_ScrpManagerVenta")]
    partial class ScrpManagerVenta
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WebAppVentaDSI.Data.ApplicationDbContext+Usuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValue("0");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.CargoEmpleado", b =>
                {
                    b.Property<int>("IdCargoEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCargoEmpleado"), 1L, 1);

                    b.Property<string>("NombreCargoEmpleado")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("IdCargoEmpleado");

                    b.ToTable("CargoEmpleado");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"), 1L, 1);

                    b.Property<string>("ApellidosCliente")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.Property<string>("DNICliente")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("DireccionCliente")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("FechaNacCliente")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SexoCliente")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("TelefonoCliente")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.Comprobante", b =>
                {
                    b.Property<int>("IdComprobante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdComprobante"), 1L, 1);

                    b.Property<DateTime>("FechaEmisionComprobante")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoComprobante")
                        .HasColumnType("int");

                    b.HasKey("IdComprobante");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdEmpleado");

                    b.HasIndex("IdTipoComprobante");

                    b.ToTable("Comprobante");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.DetalleComprobante", b =>
                {
                    b.Property<int>("IdDetalleComprobante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalleComprobante"), 1L, 1);

                    b.Property<int>("CantidadDetalleComprobante")
                        .HasColumnType("int");

                    b.Property<int>("IdComprobante")
                        .HasColumnType("int");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.HasKey("IdDetalleComprobante");

                    b.HasIndex("IdComprobante");

                    b.HasIndex("IdProducto");

                    b.ToTable("DetalleComprobante");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.DetalleEmpleado", b =>
                {
                    b.Property<int>("IdDetalleEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalleEmpleado"), 1L, 1);

                    b.Property<DateTime>("FechaDetalleEmpleado")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.HasKey("IdDetalleEmpleado");

                    b.HasIndex("IdEmpleado");

                    b.HasIndex("IdEstado");

                    b.ToTable("DetalleEmpleado");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.DetalleTipoPago", b =>
                {
                    b.Property<int>("IdDetalleTipoPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalleTipoPago"), 1L, 1);

                    b.Property<int>("IdComprobante")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoPago")
                        .HasColumnType("int");

                    b.Property<double>("PagoDetallePago")
                        .HasColumnType("float");

                    b.HasKey("IdDetalleTipoPago");

                    b.HasIndex("IdComprobante");

                    b.HasIndex("IdTipoPago");

                    b.ToTable("DetalleTipoPago");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.Empleado", b =>
                {
                    b.Property<int>("IdEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmpleado"), 1L, 1);

                    b.Property<string>("ApellidosEmpleado")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.Property<string>("DNIEmpleado")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("DireccionEmpleado")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("FechaNacEmpleado")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCargoEmpleado")
                        .HasColumnType("int");

                    b.Property<string>("NombreEmpleado")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("SexoEmpleado")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("TelefonoEmpleado")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("IdEmpleado");

                    b.HasIndex("IdCargoEmpleado");

                    b.ToTable("Empleado");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.Estado", b =>
                {
                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstado"), 1L, 1);

                    b.Property<string>("NombreEstado")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdEstado");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.FamiliaProducto", b =>
                {
                    b.Property<int>("IdFamiliaProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFamiliaProducto"), 1L, 1);

                    b.Property<string>("NombreFamiliaProducto")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("IdFamiliaProducto");

                    b.ToTable("FamiliaProducto");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.MarcaProducto", b =>
                {
                    b.Property<int>("IdMarcaProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMarcaProducto"), 1L, 1);

                    b.Property<string>("NombreMarcaProducto")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("IdMarcaProducto");

                    b.ToTable("MarcaProducto");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProducto"), 1L, 1);

                    b.Property<string>("DescripcionProducto")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IdFamiliaProducto")
                        .HasColumnType("int");

                    b.Property<int>("IdMarcaProducto")
                        .HasColumnType("int");

                    b.Property<string>("ModeloProducto")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<double>("PrecioCompraProducto")
                        .HasColumnType("float");

                    b.Property<double>("PrecioVentaProducto")
                        .HasColumnType("float");

                    b.Property<int>("StockProducto")
                        .HasColumnType("int");

                    b.HasKey("IdProducto");

                    b.HasIndex("IdFamiliaProducto");

                    b.HasIndex("IdMarcaProducto");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.TipoComprobante", b =>
                {
                    b.Property<int>("IdTipoComprobante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoComprobante"), 1L, 1);

                    b.Property<string>("NombreTipoComprobante")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("IdTipoComprobante");

                    b.ToTable("TipoComprobante");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.TipoPago", b =>
                {
                    b.Property<int>("IdTipoPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoPago"), 1L, 1);

                    b.Property<string>("NombreTipoPago")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("IdTipoPago");

                    b.ToTable("TipoPago");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebAppVentaDSI.Data.ApplicationDbContext+Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebAppVentaDSI.Data.ApplicationDbContext+Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAppVentaDSI.Data.ApplicationDbContext+Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebAppVentaDSI.Data.ApplicationDbContext+Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.Comprobante", b =>
                {
                    b.HasOne("WebAppVentaDSI.Models.Cliente", "Cliente")
                        .WithMany("Comprobante")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAppVentaDSI.Models.Empleado", "Empleado")
                        .WithMany("Comprobante")
                        .HasForeignKey("IdEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAppVentaDSI.Models.TipoComprobante", "TipoComprobante")
                        .WithMany("Comprobante")
                        .HasForeignKey("IdTipoComprobante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Empleado");

                    b.Navigation("TipoComprobante");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.DetalleComprobante", b =>
                {
                    b.HasOne("WebAppVentaDSI.Models.Comprobante", "Comprobante")
                        .WithMany("DetalleComprobante")
                        .HasForeignKey("IdComprobante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAppVentaDSI.Models.Producto", "Producto")
                        .WithMany("DetalleComprobante")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comprobante");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.DetalleEmpleado", b =>
                {
                    b.HasOne("WebAppVentaDSI.Models.Empleado", "Empleado")
                        .WithMany("DetalleEmpleado")
                        .HasForeignKey("IdEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAppVentaDSI.Models.Estado", "Estado")
                        .WithMany("DetalleEmpleado")
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.DetalleTipoPago", b =>
                {
                    b.HasOne("WebAppVentaDSI.Models.Comprobante", "Comprobante")
                        .WithMany("DetalleTipoPago")
                        .HasForeignKey("IdComprobante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAppVentaDSI.Models.TipoPago", "TipoPago")
                        .WithMany("DetalleTipoPago")
                        .HasForeignKey("IdTipoPago")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comprobante");

                    b.Navigation("TipoPago");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.Empleado", b =>
                {
                    b.HasOne("WebAppVentaDSI.Models.CargoEmpleado", "CargoEmpleado")
                        .WithMany("Empleado")
                        .HasForeignKey("IdCargoEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CargoEmpleado");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.Producto", b =>
                {
                    b.HasOne("WebAppVentaDSI.Models.FamiliaProducto", "FamiliaProducto")
                        .WithMany("Producto")
                        .HasForeignKey("IdFamiliaProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAppVentaDSI.Models.MarcaProducto", "MarcaProducto")
                        .WithMany("Producto")
                        .HasForeignKey("IdMarcaProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FamiliaProducto");

                    b.Navigation("MarcaProducto");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.CargoEmpleado", b =>
                {
                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.Cliente", b =>
                {
                    b.Navigation("Comprobante");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.Comprobante", b =>
                {
                    b.Navigation("DetalleComprobante");

                    b.Navigation("DetalleTipoPago");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.Empleado", b =>
                {
                    b.Navigation("Comprobante");

                    b.Navigation("DetalleEmpleado");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.Estado", b =>
                {
                    b.Navigation("DetalleEmpleado");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.FamiliaProducto", b =>
                {
                    b.Navigation("Producto");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.MarcaProducto", b =>
                {
                    b.Navigation("Producto");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.Producto", b =>
                {
                    b.Navigation("DetalleComprobante");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.TipoComprobante", b =>
                {
                    b.Navigation("Comprobante");
                });

            modelBuilder.Entity("WebAppVentaDSI.Models.TipoPago", b =>
                {
                    b.Navigation("DetalleTipoPago");
                });
#pragma warning restore 612, 618
        }
    }
}