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

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<AssignTask> AssignTasks { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<HoursWorked> HoursWorkeds { get; set; } = null!;
        public virtual DbSet<Leave> Leaves { get; set; } = null!;
        public virtual DbSet<Pay> Pays { get; set; } = null!;
        public virtual DbSet<PayType> PayTypes { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<AssignTask>(entity =>
            {
                entity.ToTable("AssignTask");

                entity.Property(e => e.AssignTaskId).HasColumnName("AssignTask_Id");

                entity.Property(e => e.AssignTaskName)
                    .IsUnicode(false)
                    .HasColumnName("AssignTask_Name");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AssignTasks)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AssignTask__Employee_I__6DCC4D03");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityId).ValueGeneratedNever();

                entity.Property(e => e.CityName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CityStateId).HasColumnName("City_StateId");

                entity.HasOne(d => d.CityState)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CityStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_State");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.CountryId).ValueGeneratedNever();

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(3)
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

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Employee_Id");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("Birth_Date");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");

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

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_City");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__Depart__6EC0713C");

                entity.HasOne(d => d.Country)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Country");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__Positi__6FB49575");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_State");
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Hours_Wor__Emplo__70A8B9AE");
            });

            modelBuilder.Entity<Leave>(entity =>
            {
                entity.ToTable("Leave");

                entity.Property(e => e.LeaveId).HasColumnName("Leave_Id");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.ReasonForLeave)
                    .IsUnicode(false)
                    .HasColumnName("Reason_For_Leave");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Leaves)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Leave__Employee___6CD828CA");
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
                    .HasConstraintName("FK__Pay__Employee_Id__719CDDE7");

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
                    .HasConstraintName("FK__Pay_Type__Employ__72910220");

                entity.HasOne(d => d.Pay)
                    .WithMany(p => p.PayTypes)
                    .HasForeignKey(d => d.PayId)
                    .HasConstraintName("FK__Pay_Type__Pay_Id__4CA06362");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.PositionId).HasColumnName("Position_Id");

                entity.Property(e => e.PositionName)
                    .IsUnicode(false)
                    .HasColumnName("Position_Name");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("State");

                entity.Property(e => e.StateId).ValueGeneratedNever();

                entity.Property(e => e.StateCountryId).HasColumnName("State_CountryId");

                entity.Property(e => e.StateName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.StateCountry)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.StateCountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_State_Country");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
