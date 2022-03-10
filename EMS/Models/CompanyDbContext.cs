using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EMS.Models
{
    public partial class CompanyDbContext : DbContext
    {
        public CompanyDbContext()
        {
        }

        public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<HoursWorked> HoursWorkeds { get; set; } = null!;
        public virtual DbSet<Leave> Leaves { get; set; } = null!;
        public virtual DbSet<Pay> Pays { get; set; } = null!;
        public virtual DbSet<PayType> PayTypes { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.AddressId).HasColumnName("Address_Id");

                entity.Property(e => e.Address1)
                    .IsUnicode(false)
                    .HasColumnName("Address");

                entity.Property(e => e.CityId).HasColumnName("City_Id");

                entity.Property(e => e.CountryId).HasColumnName("Country_Id");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("Postal_Code");

                entity.Property(e => e.StateId).HasColumnName("State_Id");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Admin__1788CC4C588B3C3E");

                entity.ToTable("Admin");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cities_Regions");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");

                entity.Property(e => e.DepartmentName)
                    .IsUnicode(false)
                    .HasColumnName("Department_Name");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.AddressId).HasColumnName("Address_Id");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("Birth_Date");

                entity.Property(e => e.DepartmentId)
                    .HasMaxLength(10)
                    .HasColumnName("Department_Id")
                    .IsFixedLength();

                entity.Property(e => e.EmailId)
                    .IsUnicode(false)
                    .HasColumnName("Email_Id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PositionId).HasColumnName("Position_Id");

                entity.Property(e => e.Profile).IsUnicode(false);
            });

            modelBuilder.Entity<HoursWorked>(entity =>
            {
                entity.HasKey(e => e.PunchId)
                    .HasName("PK__Hours_Wo__BE0738B885545C27");

                entity.ToTable("Hours_Worked");

                entity.Property(e => e.PunchId).HasColumnName("Punch_Id");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.PunchInTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Punch_In_Time");

                entity.Property(e => e.PunchOutTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Punch_out_Time");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.HoursWorkeds)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Hours_Wor__Emplo__3C69FB99");
            });

            modelBuilder.Entity<Leave>(entity =>
            {
                entity.ToTable("Leave");

                entity.Property(e => e.LeaveId)
                    .ValueGeneratedNever()
                    .HasColumnName("Leave_Id");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.ReasonForLeave)
                    .IsUnicode(false)
                    .HasColumnName("Reason_For_Leave");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Leaves)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Leave__Employee___4222D4EF");
            });

            modelBuilder.Entity<Pay>(entity =>
            {
                entity.ToTable("Pay");

                entity.Property(e => e.PayId)
                    .ValueGeneratedNever()
                    .HasColumnName("Pay_Id");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.NetPay).HasColumnName("Net_Pay");

                entity.Property(e => e.PunchId).HasColumnName("Punch_Id");

                entity.Property(e => e.TotalHours).HasColumnName("Total_hours");

                entity.Property(e => e.TotalPay).HasColumnName("Total_Pay");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Pays)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pay__Employee_Id__47DBAE45");

                entity.HasOne(d => d.Punch)
                    .WithMany(p => p.Pays)
                    .HasForeignKey(d => d.PunchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pay__Punch_Id__48CFD27E");
            });

            modelBuilder.Entity<PayType>(entity =>
            {
                entity.ToTable("Pay_Type");

                entity.Property(e => e.PayTypeId).HasColumnName("Pay_Type_Id");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.PayId).HasColumnName("Pay_Id");

                entity.Property(e => e.PayType1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pay_Type");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PayTypes)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Pay_Type__Employ__4BAC3F29");

                entity.HasOne(d => d.Pay)
                    .WithMany(p => p.PayTypes)
                    .HasForeignKey(d => d.PayId)
                    .HasConstraintName("FK__Pay_Type__Pay_Id__4CA06362");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Regions)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Regions_Countries");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.TaskId)
                    .ValueGeneratedNever()
                    .HasColumnName("Task_Id");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.TaskName)
                    .IsUnicode(false)
                    .HasColumnName("Task_Name");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Task__Employee_I__44FF419A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
