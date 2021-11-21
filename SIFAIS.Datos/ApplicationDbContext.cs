using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SIFAIS.Modelos.Datos;
using SIFAIS.Modelos.Views;

#nullable disable

namespace SIFAIS.Datos
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblActivosFisico> TblActivosFisicos { get; set; }
        public virtual DbSet<TblActivosPrestado> TblActivosPrestados { get; set; }
        public virtual DbSet<TblDepartamento> TblDepartamentos { get; set; }
        public virtual DbSet<TblDocumentacionSifai> TblDocumentacionSifais { get; set; }
        public virtual DbSet<TblDonacione> TblDonaciones { get; set; }
        public virtual DbSet<TblDonante> TblDonantes { get; set; }
        public virtual DbSet<TblEspacio> TblEspacios { get; set; }
        public virtual DbSet<TblEstadoActivo> TblEstadoActivos { get; set; }
        public virtual DbSet<TblEstadoPrestamo> TblEstadoPrestamos { get; set; }
        public virtual DbSet<TblGasto> TblGastos { get; set; }
        public virtual DbSet<TblMensajero> TblMensajeros { get; set; }
        public virtual DbSet<TblResponsable> TblResponsables { get; set; }
        public virtual DbSet<TblResponsableDonacion> TblResponsableDonacions { get; set; }
        public virtual DbSet<TblRolUsuario> TblRolUsuarios { get; set; }
        public virtual DbSet<TblSede> TblSedes { get; set; }
        public virtual DbSet<TblTipoActivo> TblTipoActivos { get; set; }
        public virtual DbSet<TblTipoDonacion> TblTipoDonacions { get; set; }
        public virtual DbSet<TblTipoDonante> TblTipoDonantes { get; set; }
        public virtual DbSet<TblTipoGasto> TblTipoGastos { get; set; }
        public virtual DbSet<TblTipoResponsable> TblTipoResponsables { get; set; }
        public virtual DbSet<TblUsuario> TblUsuarios { get; set; }
        public virtual DbSet<DonanteView> DonanteView { get; set; }
        public virtual DbSet<DonacionesView> DonacionesView { get; set; }
        public virtual DbSet<UsuarioView> UsuarioViews { get; set; }
        public virtual DbSet<ActivosFisicosView> ActivosFisicosViews { get; set; }
        public virtual DbSet<ResponsableActivoView> ResponsableActivoViews { get; set; }
        public virtual DbSet<ActivosPrestadosView> ActivosPrestadosViews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1253_CI_AS");

            modelBuilder.Entity<ActivosFisicosView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ActivosFisicosView");

                entity.Property(e => e.CodArticulo)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Condicion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Sede)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ActivosPrestadosView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ActivosPrestadosView");

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionActivo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoActivo)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.LugarPrestamo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreActivo)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Responsable)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TipoActivo)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DonacionesView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DonacionesView");

                entity.Property(e => e.Cantidad)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentacionSifais)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("DocumentacionSIFAIS");

                entity.Property(e => e.Donante)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Espacio)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FechaDonacion).HasColumnType("datetime");

                entity.Property(e => e.Mensajero)
                    .IsRequired()
                    .HasMaxLength(51)
                    .IsUnicode(false);

                entity.Property(e => e.ResponsableDonacion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDonacion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DonanteView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DonanteView");

                entity.Property(e => e.CodigoExterno)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDonante)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ResponsableActivoView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ResponsableActivoView");

                entity.Property(e => e.Celular)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblActivosFisico>(entity =>
            {
                entity.ToTable("Tbl_ActivosFisicos");

                entity.Property(e => e.CodArticulo)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaDeIngreso).HasColumnType("datetime");

                entity.Property(e => e.Foto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.TblActivosFisicos)
                    .HasForeignKey(d => d.IdDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivosFisicos_Departamento");

                entity.HasOne(d => d.IdEstadoActivoNavigation)
                    .WithMany(p => p.TblActivosFisicos)
                    .HasForeignKey(d => d.IdEstadoActivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivosFisicos_EstadoActivos");

                entity.HasOne(d => d.IdSedeNavigation)
                    .WithMany(p => p.TblActivosFisicos)
                    .HasForeignKey(d => d.IdSede)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivosFisicos_Sede");

                entity.HasOne(d => d.IdTipoActivoNavigation)
                    .WithMany(p => p.TblActivosFisicos)
                    .HasForeignKey(d => d.IdTipoActivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivosFisicos_TipoActivo");
            });

            modelBuilder.Entity<TblActivosPrestado>(entity =>
            {
                entity.ToTable("Tbl_ActivosPrestados");

                entity.Property(e => e.Detalle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.LugarPrestamo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdActivoNavigation)
                    .WithMany(p => p.TblActivosPrestados)
                    .HasForeignKey(d => d.IdActivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivoPrestado_ActivosFisicos");

                entity.HasOne(d => d.IdActivo1)
                    .WithMany(p => p.TblActivosPrestados)
                    .HasForeignKey(d => d.IdActivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivoPrestado_EstadoPrestamo");

                entity.HasOne(d => d.IdResponsableNavigation)
                    .WithMany(p => p.TblActivosPrestados)
                    .HasForeignKey(d => d.IdResponsable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivoPrestado_Responsable");
            });

            modelBuilder.Entity<TblDepartamento>(entity =>
            {
                entity.ToTable("Tbl_Departamentos");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Detalles)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblDocumentacionSifai>(entity =>
            {
                entity.ToTable("Tbl_DocumentacionSIFAIS");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblDonacione>(entity =>
            {
                entity.ToTable("Tbl_Donaciones");

                entity.Property(e => e.Cantidad)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Detalles)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaDonacion).HasColumnType("datetime");

                entity.Property(e => e.IdDocSifais).HasColumnName("IdDocSIFAIS");

                entity.HasOne(d => d.IdDocSifaisNavigation)
                    .WithMany(p => p.TblDonaciones)
                    .HasForeignKey(d => d.IdDocSifais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Donaciones_DocumentacionSIFAIS");

                entity.HasOne(d => d.IdDonanteNavigation)
                    .WithMany(p => p.TblDonaciones)
                    .HasForeignKey(d => d.IdDonante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Donaciones_Donante");

                entity.HasOne(d => d.IdEspacioNavigation)
                    .WithMany(p => p.TblDonaciones)
                    .HasForeignKey(d => d.IdEspacio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Donaciones_Espacio");

                entity.HasOne(d => d.IdMensajeroNavigation)
                    .WithMany(p => p.TblDonaciones)
                    .HasForeignKey(d => d.IdMensajero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Donaciones_Mensajero");

                entity.HasOne(d => d.IdResponsableDonacionNavigation)
                    .WithMany(p => p.TblDonaciones)
                    .HasForeignKey(d => d.IdResponsableDonacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Donaciones_ResponsableDonacion");

                entity.HasOne(d => d.IdSedeNavigation)
                    .WithMany(p => p.TblDonaciones)
                    .HasForeignKey(d => d.IdSede)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Donaciones_Sede");

                entity.HasOne(d => d.IdTipoDonacionNavigation)
                    .WithMany(p => p.TblDonaciones)
                    .HasForeignKey(d => d.IdTipoDonacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Donaciones_TipoDonacion");
            });

            modelBuilder.Entity<TblDonante>(entity =>
            {
                entity.ToTable("Tbl_Donante");

                entity.Property(e => e.CodigoExterno)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoDonanteNavigation)
                    .WithMany(p => p.TblDonantes)
                    .HasForeignKey(d => d.IdTipoDonante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Donante_TipoDonante");
            });

            modelBuilder.Entity<TblEspacio>(entity =>
            {
                entity.ToTable("Tbl_Espacio");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Detalles)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblEstadoActivo>(entity =>
            {
                entity.ToTable("Tbl_EstadoActivos");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Detalles)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblEstadoPrestamo>(entity =>
            {
                entity.ToTable("Tbl_EstadoPrestamo");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Detalles)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblGasto>(entity =>
            {
                entity.ToTable("Tbl_Gastos");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Detalle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSedeNavigation)
                    .WithMany(p => p.TblGastos)
                    .HasForeignKey(d => d.IdSede)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gasto_Sede");

                entity.HasOne(d => d.IdTipoGastoNavigation)
                    .WithMany(p => p.TblGastos)
                    .HasForeignKey(d => d.IdTipoGasto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gastos_TipoGasto");
            });

            modelBuilder.Entity<TblMensajero>(entity =>
            {
                entity.ToTable("Tbl_Mensajero");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblResponsable>(entity =>
            {
                entity.ToTable("Tbl_Responsable");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoExterno)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoResponsableNavigation)
                    .WithMany(p => p.TblResponsables)
                    .HasForeignKey(d => d.IdTipoResponsable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Responsable_TipoResponsable");
            });

            modelBuilder.Entity<TblResponsableDonacion>(entity =>
            {
                entity.ToTable("Tbl_ResponsableDonacion");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblRolUsuario>(entity =>
            {
                entity.ToTable("Tbl_RolUsuario");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Detalles)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSede>(entity =>
            {
                entity.ToTable("Tbl_Sede");

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Detalles)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTipoActivo>(entity =>
            {
                entity.ToTable("Tbl_TipoActivos");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Detalles)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTipoDonacion>(entity =>
            {
                entity.ToTable("Tbl_TipoDonacion");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Detalles)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTipoDonante>(entity =>
            {
                entity.ToTable("Tbl_TipoDonante");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Detalles)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTipoGasto>(entity =>
            {
                entity.ToTable("Tbl_TipoGasto");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Detalles)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTipoResponsable>(entity =>
            {
                entity.ToTable("Tbl_TipoResponsable");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Detalles)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUsuario>(entity =>
            {
                entity.ToTable("Tbl_Usuario");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoExterno)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRolUsuarioNavigation)
                    .WithMany(p => p.TblUsuarios)
                    .HasForeignKey(d => d.IdRolUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Rol");

                entity.HasOne(d => d.IdSedeNavigation)
                    .WithMany(p => p.TblUsuarios)
                    .HasForeignKey(d => d.IdSede)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Sede");
            });

            modelBuilder.Entity<UsuarioView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("UsuarioView");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Sede)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
