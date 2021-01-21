using test_aloe.Models;  
using Microsoft.EntityFrameworkCore;  
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
  
namespace MaestroDetalle.DBContexts  
{  
    public class MyDBContext : DbContext  
    {  
        public DbSet<Usuario> Usuarios { get; set; }  
        public DbSet<Departamento> Departamentos { get; set; }  
  
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)  
        {   
        }  
  
        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {  
            // Use Fluent API to configure  
  
            // Map entities to tables  
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");  
            modelBuilder.Entity<Departamento>().ToTable("Departments");  
            
  

  
            // Configure Primary Keys  
            modelBuilder.Entity<Usuario>().HasKey(us => us.Id).HasName("PK_Usuario");  
            modelBuilder.Entity<Departamento>().HasKey(dep => dep.Id).HasName("PK_Departamento");  
        
  
            // Configure columns  
            modelBuilder.Entity<Usuario>().Property(us => us.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();  
            modelBuilder.Entity<Usuario>().Property(us => us.Nombre).HasColumnType("nvarchar(100)").IsRequired();  
            modelBuilder.Entity<Usuario>().Property(us => us.Apellido).HasColumnType("nvarchar(100)").IsRequired();  
            modelBuilder.Entity<Usuario>().Property(us => us.Genero).HasColumnType("nvarchar(20)").IsRequired();  
            modelBuilder.Entity<Usuario>().Property(us => us.Cedula).HasColumnType("nvarchar(100)").IsRequired();  
            modelBuilder.Entity<Usuario>().Property(us => us.FechaNacimiento).HasColumnType("nvarchar(100)").IsRequired();  
            modelBuilder.Entity<Usuario>().Property(us => us.DepartamentoId).HasColumnType("int").IsRequired();  
            modelBuilder.Entity<Usuario>().Property(us => us.cargo).HasColumnType("nvarchar(100)").IsRequired();  
            modelBuilder.Entity<Usuario>().Property(us => us.Supervisor).HasColumnType("nvarchar(100)").IsRequired();  
          

            modelBuilder.Entity<Departamento>().Property(dep => dep.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();  
            modelBuilder.Entity<Departamento>().Property(dep => dep.Nombre).HasColumnType("nvarchar(100)").IsRequired();  
            modelBuilder.Entity<Departamento>().Property(dep => dep.Codigo).HasColumnType("nvarchar(100)").IsRequired();  
    
            // Configure relationships  
            modelBuilder.Entity<Usuario>().HasOne(us => us.Departments).WithMany(dep => dep.Usuarios).HasForeignKey(dep => dep.DepartamentoId).HasConstraintName("FK_usuario_departamento");  
            modelBuilder.Entity<Departamento>().HasMany(dep => dep.Usuarios).WithOne(us => us.Departments).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_departamento_usuario");  
           

        }  
    }  
}  