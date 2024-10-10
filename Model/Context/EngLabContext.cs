using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngLabAPI.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace EngLabAPI.Model.Context
{
    public class EngLabContext : DbContext
    {
        public EngLabContext(DbContextOptions options) : base(options)
        {
        }

        #region DbSet

        public virtual DbSet<Staff> Staff { get; set; }

        public virtual DbSet<StaffRole> StaffRole { get; set; }

        public virtual DbSet<Student> Student { get; set; }

        public virtual DbSet<Teacher> Teacher { get; set; }

        public virtual DbSet<Class> Class { get; set; }

        public virtual DbSet<ClassStudent> ClassStudents { get; set; }

        public virtual DbSet<Course> Course { get; set; }

        public virtual DbSet<ClassWeekday> ClassWeekday { get; set; }

        public virtual DbSet<Level> Level { get; set; }

        public virtual DbSet<Language> Language { get; set; }

        public virtual DbSet<Payment> Payment { get; set; }

        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }

        public virtual DbSet<Weekday> Weekday { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EngLabContext).Assembly);
        }
    }
}