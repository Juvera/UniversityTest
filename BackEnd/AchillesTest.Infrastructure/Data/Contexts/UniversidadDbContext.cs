using AchillesTest.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using AchillesTest.Domain.StoreProcedure;


namespace AchillesTest.Infrastructure.Data.Contexts
{
    public class UniversidadDbContext : DbContext
    {
        public UniversidadDbContext(DbContextOptions<UniversidadDbContext> options) : base(options) { }

        public DbSet<Provincia> TB_PROVINCIA { get; set; }
        public DbSet<Distrito> TB_DISTRITO { get; set; }
        public DbSet<Estudiante> TB_ESTUDIANTE { get; set; }
        public DbSet<Docente> TB_DOCENTE { get; set; }
        public DbSet<Profesion> TB_PROFESION { get; set; }
        public DbSet<Curso> TB_CURSO { get; set; }
        public DbSet<Asignacion> TB_ASIGNACION { get; set; }
        public DbSet<Matricula> TB_MATRICULA { get; set; }
        public DbSet<ProvinciaPopularResult> ProvinciaPopularResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de las entidades y sus claves primarias
            modelBuilder.Entity<Provincia>().ToTable("TB_PROVINCIA").HasKey(p => p.IdProvincia);
            modelBuilder.Entity<Distrito>().ToTable("TB_DISTRITO").HasKey(d => d.IdDistrito);
            modelBuilder.Entity<Estudiante>().ToTable("TB_ESTUDIANTE").HasKey(e => e.IdEstudiante);
            modelBuilder.Entity<Docente>().ToTable("TB_DOCENTE").HasKey(d => d.IdDocente);
            modelBuilder.Entity<Profesion>().ToTable("TB_PROFESION").HasKey(p => p.IdProfesion);
            modelBuilder.Entity<Curso>().ToTable("TB_CURSO").HasKey(c => c.IdCurso);
            modelBuilder.Entity<Asignacion>().ToTable("TB_ASIGNACION").HasKey(a => a.IdAsignacion);
            modelBuilder.Entity<Matricula>().ToTable("TB_MATRICULA").HasKey(m => m.IdMatricula);
            // Configuracion de los procedimientos almacenados
            modelBuilder.Entity<ProvinciaPopularResult>().HasNoKey();
            // configuración de las relaciones entre entidades
            modelBuilder.Entity<Distrito>()
                .HasOne(d => d.Provincia)
                .WithMany(p => p.Distritos)
                .HasForeignKey(d => d.Idprovincia);

            modelBuilder.Entity<Estudiante>()
                .HasOne(e => e.Distrito)
                .WithMany(d => d.Estudiantes)
                .HasForeignKey(e => e.IdDistrito);

            modelBuilder.Entity<Asignacion>()
                .HasOne(a => a.Docente)
                .WithMany(d => d.Asignaciones)
                .HasForeignKey(a => a.IdDocente);

            modelBuilder.Entity<Asignacion>()
                .HasOne(a => a.Curso)
                .WithMany(c => c.Asignaciones)
                .HasForeignKey(a => a.IdCurso);

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Estudiante)
                .WithMany(e => e.Matriculas)
                .HasForeignKey(m => m.IdEstudiante);

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Curso)
                .WithMany(c => c.Matriculas)
                .HasForeignKey(m => m.IdCurso);
        }
    }
}
