using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mysql.Models
{
    public partial class demoContext : DbContext
    {
        //public demoContext()
        //{
        //}

        //public demoContext(DbContextOptions<demoContext> options)
        //{
        //}

        public demoContext(DbContextOptions<demoContext> options) : base(options)
        {
        }


        public virtual DbSet<Dept> Depts { get; set; } = null!;
        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; } = null!;
        public virtual DbSet<Emp> Emps { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<staff> staff { get; set; } = null!;


        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseMySql("server=localhost;port=3306;database=demo;uid=root;pwd=mysql", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
        //            }
        //        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //           .SetBasePath(Directory.GetCurrentDirectory())
        //           .AddJsonFile("appsettings.json")
        //           .Build();
        //        var connectionString = configuration.GetConnectionString("DefaultConnection");
        //        optionsBuilder.UseMySql(connectionString,new MySqlServerVersion(new Version(8, 0, 22)));
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Dept>(entity =>
            {
                entity.HasKey(e => e.Deptno)
                    .HasName("PRIMARY");

                entity.ToTable("dept");

                entity.Property(e => e.Deptno)
                    .ValueGeneratedNever()
                    .HasColumnName("deptno");

                entity.Property(e => e.Dname)
                    .HasMaxLength(14)
                    .HasColumnName("dname");

                entity.Property(e => e.Loc)
                    .HasMaxLength(13)
                    .HasColumnName("loc");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasKey(e => e.Empno)
                    .HasName("PRIMARY");

                entity.ToTable("emp");

                entity.HasIndex(e => e.Deptno, "emp_fk");

                entity.Property(e => e.Empno)
                    .ValueGeneratedNever()
                    .HasColumnName("empno");

                entity.Property(e => e.Comm).HasColumnName("comm");

                entity.Property(e => e.Deptno).HasColumnName("deptno");

                entity.Property(e => e.Ename)
                    .HasMaxLength(10)
                    .HasColumnName("ename");

                entity.Property(e => e.Hiredate)
                    .HasColumnType("datetime")
                    .HasColumnName("hiredate");

                entity.Property(e => e.Job)
                    .HasMaxLength(9)
                    .HasColumnName("job");

                entity.Property(e => e.Mgr).HasColumnName("mgr");

                entity.Property(e => e.Sal).HasColumnName("sal");

                entity.HasOne(d => d.DeptnoNavigation)
                    .WithMany(p => p.Emps)
                    .HasForeignKey(d => d.Deptno)
                    .HasConstraintName("emp_fk");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Addresss)
                    .HasMaxLength(130)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("teachers");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Addresss)
                    .HasMaxLength(130)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
