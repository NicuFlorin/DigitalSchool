using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Entities.Uploads;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
            IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            builder.Entity<StudentEnrollment>().HasKey(s => s.Id);
            builder.Entity<AppUser>()
          .HasMany(s => s.StudentEnrolements)
          .WithOne(u => u.AppUser)
          .HasForeignKey(q => q.AppUserId)
          .IsRequired();
            builder.Entity<Cohort>()
          .HasMany(s => s.Students)
          .WithOne(u => u.Cohort)
          .HasForeignKey(q => q.CohortId)
          .IsRequired();

            builder.Entity<QuestionAnswear>()
            .HasMany(a => a.Answears)
            .WithOne(c => c.QuestionAnswear)
            .HasForeignKey(q => q.QuestionAnswearId)
            .IsRequired();

            builder.Entity<Choice>()
            .HasMany(a => a.Answears)
            .WithOne(c => c.Choice)
            .HasForeignKey(ch => ch.ChoiceId)
            .IsRequired();
            builder.ApplyUtcDateTimeConverter();


        }


        public DbSet<Context> Context { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Cohort> Cohort { get; set; }
        public DbSet<StudentEnrollment> StudentEnrollment { get; set; }
        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<Folder> Folder { get; set; }
        public DbSet<AssignmentSubmit> AssignmentSubmit { get; set; }
        public DbSet<QuizSubmit> QuizSubmit { get; set; }
        public DbSet<Resource> Resource { get; set; }
        public DbSet<Upload> Upload { get; set; }
        public DbSet<FileUpload> FileUpload { get; set; }



    }
    public static class UtcDateAnnotation
    {
        private const String IsUtcAnnotation = "IsUtc";
        private static readonly ValueConverter<DateTime, DateTime> UtcConverter =
          new ValueConverter<DateTime, DateTime>(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        private static readonly ValueConverter<DateTime?, DateTime?> UtcNullableConverter =
          new ValueConverter<DateTime?, DateTime?>(v => v, v => v == null ? v : DateTime.SpecifyKind(v.Value, DateTimeKind.Utc));

        public static PropertyBuilder<TProperty> IsUtc<TProperty>(this PropertyBuilder<TProperty> builder, Boolean isUtc = true) =>
          builder.HasAnnotation(IsUtcAnnotation, isUtc);

        public static Boolean IsUtc(this IMutableProperty property) =>
          ((Boolean?)property.FindAnnotation(IsUtcAnnotation)?.Value) ?? true;

        /// <summary>
        /// Make sure this is called after configuring all your entities.
        /// </summary>
        public static void ApplyUtcDateTimeConverter(this ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (!property.IsUtc())
                    {
                        continue;
                    }

                    if (property.ClrType == typeof(DateTime))
                    {
                        property.SetValueConverter(UtcConverter);
                    }

                    if (property.ClrType == typeof(DateTime?))
                    {
                        property.SetValueConverter(UtcNullableConverter);
                    }
                }
            }
        }
    }
}