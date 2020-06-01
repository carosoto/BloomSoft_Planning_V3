namespace BloomSoft_V2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BSModel : DbContext
    {
        public BSModel()
            : base("name=BSModel2")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<EstadisticasPartida> EstadisticasPartida { get; set; }
        public virtual DbSet<Licencia> Licencia { get; set; }
        public virtual DbSet<LicenciaUsuario> LicenciaUsuario { get; set; }
        public virtual DbSet<Participante> Participante { get; set; }
        public virtual DbSet<PartidaJuego> PartidaJuego { get; set; }
        public virtual DbSet<PartidaJugador> PartidaJugador { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<Requerimiento> Requerimiento { get; set; }
        public virtual DbSet<TarjetaRequerim> TarjetaRequerim { get; set; }
        public virtual DbSet<Taxonomia> Taxonomia { get; set; }
        public virtual DbSet<VerbosTarjeta> VerbosTarjeta { get; set; }
        public virtual DbSet<Verbotax> Verbotax { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<Tarea> Tarea { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.Participante)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.id_usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.Pago)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.id_usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.PartidaJugador)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.id_usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.PartidaJuego)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.id_usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.Proyecto)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.id_usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.LicenciaUsuario)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.id_usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LicenciaUsuario>()
                .HasMany(e => e.Licencia)
                .WithRequired(e => e.LicenciaUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LicenciaUsuario>()
                .HasMany(e => e.Pago)
                .WithRequired(e => e.LicenciaUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PartidaJuego>()
                .HasMany(e => e.EstadisticasPartida)
                .WithRequired(e => e.PartidaJuego)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PartidaJuego>()
                .HasMany(e => e.PartidaJugador)
                .WithRequired(e => e.PartidaJuego)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PartidaJugador>()
                .HasMany(e => e.EstadisticasPartida)
                .WithRequired(e => e.PartidaJugador)
                .HasForeignKey(e => e.id_mejorjugador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PartidaJugador>()
                .HasMany(e => e.EstadisticasPartida1)
                .WithRequired(e => e.PartidaJugador1)
                .HasForeignKey(e => e.id_peorjugador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PartidaJugador>()
                .HasMany(e => e.TarjetaRequerim)
                .WithRequired(e => e.PartidaJugador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .HasMany(e => e.Participante)
                .WithRequired(e => e.Proyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proyecto>()
                .HasMany(e => e.PartidaJuego)
                .WithRequired(e => e.Proyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proyecto>()
                .HasMany(e => e.Requerimiento)
                .WithRequired(e => e.Proyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Requerimiento>()
                .HasMany(e => e.TarjetaRequerim)
                .WithRequired(e => e.Requerimiento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TarjetaRequerim>()
                .HasMany(e => e.VerbosTarjeta)
                .WithRequired(e => e.TarjetaRequerim)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TarjetaRequerim>()
                .HasMany(e => e.Tarea)
                .WithRequired(e => e.TarjetaRequerim)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Taxonomia>()
                .Property(e => e.categoria)
                .IsUnicode(false);

            modelBuilder.Entity<Taxonomia>()
                .HasMany(e => e.TarjetaRequerim)
                .WithRequired(e => e.Taxonomia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Taxonomia>()
                .HasMany(e => e.Verbotax)
                .WithRequired(e => e.Taxonomia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Verbotax>()
                .Property(e => e.verbos)
                .IsUnicode(false);

            modelBuilder.Entity<Verbotax>()
                .HasMany(e => e.VerbosTarjeta)
                .WithRequired(e => e.Verbotax)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pago>()
                .Property(e => e.monto)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Tarea>()
                .Property(e => e.descripcion)
                .IsUnicode(false);
        }
    }
}
