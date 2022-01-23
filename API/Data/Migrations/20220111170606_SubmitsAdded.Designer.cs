﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220111170606_SubmitsAdded")]
    partial class SubmitsAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("API.Entities.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("API.Entities.AppUserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("API.Entities.Choice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isCorrect")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Choice");
                });

            modelBuilder.Entity("API.Entities.Cohort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContextId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ContextId");

                    b.ToTable("Cohort");
                });

            modelBuilder.Entity("API.Entities.Context", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ParentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Context");
                });

            modelBuilder.Entity("API.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CohortId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateFinal")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("NoOfSections")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ShortName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isWeekFormat")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CohortId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("API.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ImageId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Mark")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("QuizId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.Property<bool>("hasMultipleAnswears")
                        .HasColumnType("INTEGER");

                    b.Property<string>("shortAnswear")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ImageId")
                        .IsUnique();

                    b.HasIndex("QuizId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("API.Entities.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("WeekEnd")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("WeekStart")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("API.Entities.StudentEnrollment", b =>
                {
                    b.Property<int>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CohortId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AppUserId", "CohortId");

                    b.HasIndex("CohortId");

                    b.ToTable("StudentEnrollment");
                });

            modelBuilder.Entity("API.Entities.Upload", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfUpload")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SectionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Upload");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Upload");
                });

            modelBuilder.Entity("API.Entities.Uploads.FileUpload", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FileName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FolderId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UploadId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.HasIndex("UploadId");

                    b.ToTable("FileUpload");
                });

            modelBuilder.Entity("API.Entities.Uploads.Submit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AssignmentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentAppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentCohortId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("StudentAppUserId", "StudentCohortId");

                    b.ToTable("Submit");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("API.Entities.Assignment", b =>
                {
                    b.HasBaseType("API.Entities.Upload");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<double>("GradeToPass")
                        .HasColumnType("REAL")
                        .HasColumnName("Assignment_GradeToPass");

                    b.Property<double>("MaximumGrade")
                        .HasColumnType("REAL")
                        .HasColumnName("Assignment_MaximumGrade");

                    b.Property<DateTime>("SubmissionFrom")
                        .HasColumnType("TEXT");

                    b.HasIndex("CourseId");

                    b.HasIndex("SectionId");

                    b.HasDiscriminator().HasValue("Assignment");
                });

            modelBuilder.Entity("API.Entities.Attendance", b =>
                {
                    b.HasBaseType("API.Entities.Upload");

                    b.Property<DateTime>("Due")
                        .HasColumnType("TEXT");

                    b.HasIndex("CourseId");

                    b.HasIndex("SectionId");

                    b.HasDiscriminator().HasValue("Attendance");
                });

            modelBuilder.Entity("API.Entities.Quiz", b =>
                {
                    b.HasBaseType("API.Entities.Upload");

                    b.Property<DateTime>("CloseQuiz")
                        .HasColumnType("TEXT");

                    b.Property<double>("GradeToPass")
                        .HasColumnType("REAL");

                    b.Property<double>("MaximumGrade")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("OpenQuiz")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ShuffleActivated")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TimeLimit")
                        .HasColumnType("INTEGER");

                    b.HasIndex("CourseId");

                    b.HasIndex("SectionId");

                    b.HasDiscriminator().HasValue("Quiz");
                });

            modelBuilder.Entity("API.Entities.Uploads.Folder", b =>
                {
                    b.HasBaseType("API.Entities.Upload");

                    b.Property<int?>("ParentId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("CourseId");

                    b.HasIndex("ParentId");

                    b.HasIndex("SectionId");

                    b.HasDiscriminator().HasValue("Folder");
                });

            modelBuilder.Entity("API.Entities.AppUserRole", b =>
                {
                    b.HasOne("API.Entities.AppRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.AppUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Entities.Choice", b =>
                {
                    b.HasOne("API.Entities.Question", "Question")
                        .WithMany("Choices")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("API.Entities.Cohort", b =>
                {
                    b.HasOne("API.Entities.Context", "Context")
                        .WithMany("Cohorts")
                        .HasForeignKey("ContextId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Context");
                });

            modelBuilder.Entity("API.Entities.Context", b =>
                {
                    b.HasOne("API.Entities.Context", "Parent")
                        .WithMany("SubCategory")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("API.Entities.Course", b =>
                {
                    b.HasOne("API.Entities.Context", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Cohort", "Cohort")
                        .WithMany("Courses")
                        .HasForeignKey("CohortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.AppUser", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.Navigation("Category");

                    b.Navigation("Cohort");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("API.Entities.Question", b =>
                {
                    b.HasOne("API.Entities.Uploads.FileUpload", "Image")
                        .WithOne("Question")
                        .HasForeignKey("API.Entities.Question", "ImageId");

                    b.HasOne("API.Entities.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("API.Entities.Section", b =>
                {
                    b.HasOne("API.Entities.Course", "Course")
                        .WithMany("Sections")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("API.Entities.StudentEnrollment", b =>
                {
                    b.HasOne("API.Entities.AppUser", "AppUser")
                        .WithMany("StudentEnrolements")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Cohort", "Cohort")
                        .WithMany("Students")
                        .HasForeignKey("CohortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Cohort");
                });

            modelBuilder.Entity("API.Entities.Uploads.FileUpload", b =>
                {
                    b.HasOne("API.Entities.Uploads.Folder", "Folder")
                        .WithMany()
                        .HasForeignKey("FolderId");

                    b.HasOne("API.Entities.Upload", "Upload")
                        .WithMany("Files")
                        .HasForeignKey("UploadId");

                    b.Navigation("Folder");

                    b.Navigation("Upload");
                });

            modelBuilder.Entity("API.Entities.Uploads.Submit", b =>
                {
                    b.HasOne("API.Entities.Assignment", null)
                        .WithMany("Submits")
                        .HasForeignKey("AssignmentId");

                    b.HasOne("API.Entities.StudentEnrollment", "Student")
                        .WithMany()
                        .HasForeignKey("StudentAppUserId", "StudentCohortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("API.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("API.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("API.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("API.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Entities.Assignment", b =>
                {
                    b.HasOne("API.Entities.Course", "Course")
                        .WithMany("Assignments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Section", "Section")
                        .WithMany("Assignments")
                        .HasForeignKey("SectionId");

                    b.Navigation("Course");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("API.Entities.Attendance", b =>
                {
                    b.HasOne("API.Entities.Course", "Course")
                        .WithMany("Attendances")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Section", "Section")
                        .WithMany("Attendances")
                        .HasForeignKey("SectionId");

                    b.Navigation("Course");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("API.Entities.Quiz", b =>
                {
                    b.HasOne("API.Entities.Course", "Course")
                        .WithMany("Quizzes")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Section", "Section")
                        .WithMany("Quizzes")
                        .HasForeignKey("SectionId");

                    b.Navigation("Course");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("API.Entities.Uploads.Folder", b =>
                {
                    b.HasOne("API.Entities.Course", "Course")
                        .WithMany("Folders")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Uploads.Folder", "Parent")
                        .WithMany("Folders")
                        .HasForeignKey("ParentId");

                    b.HasOne("API.Entities.Section", "Section")
                        .WithMany("Folders")
                        .HasForeignKey("SectionId");

                    b.Navigation("Course");

                    b.Navigation("Parent");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("API.Entities.AppRole", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Navigation("StudentEnrolements");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("API.Entities.Cohort", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("API.Entities.Context", b =>
                {
                    b.Navigation("Cohorts");

                    b.Navigation("Courses");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("API.Entities.Course", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Attendances");

                    b.Navigation("Folders");

                    b.Navigation("Quizzes");

                    b.Navigation("Sections");
                });

            modelBuilder.Entity("API.Entities.Question", b =>
                {
                    b.Navigation("Choices");
                });

            modelBuilder.Entity("API.Entities.Section", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Attendances");

                    b.Navigation("Folders");

                    b.Navigation("Quizzes");
                });

            modelBuilder.Entity("API.Entities.Upload", b =>
                {
                    b.Navigation("Files");
                });

            modelBuilder.Entity("API.Entities.Uploads.FileUpload", b =>
                {
                    b.Navigation("Question");
                });

            modelBuilder.Entity("API.Entities.Assignment", b =>
                {
                    b.Navigation("Submits");
                });

            modelBuilder.Entity("API.Entities.Quiz", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("API.Entities.Uploads.Folder", b =>
                {
                    b.Navigation("Folders");
                });
#pragma warning restore 612, 618
        }
    }
}
