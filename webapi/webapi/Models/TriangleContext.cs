// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace webapi.Models
{
    public partial class TriangleContext : DbContext
    {
        public TriangleContext()
        {
        }

        public TriangleContext(DbContextOptions<TriangleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AptitudeTest> AptitudeTest { get; set; }
        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Candidate> Candidate { get; set; }
        public virtual DbSet<CandidateCv> CandidateCv { get; set; }
        public virtual DbSet<CandidateSkill> CandidateSkill { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseDetail> CourseDetail { get; set; }
        public virtual DbSet<CourseOrder> CourseOrder { get; set; }
        public virtual DbSet<Cv> Cv { get; set; }
        public virtual DbSet<Enterprise> Enterprise { get; set; }
        public virtual DbSet<Interest> Interest { get; set; }
        public virtual DbSet<InterestedArticle> InterestedArticle { get; set; }
        public virtual DbSet<InterestedCourse> InterestedCourse { get; set; }
        public virtual DbSet<InterestedCv> InterestedCv { get; set; }
        public virtual DbSet<InterestedEnterprise> InterestedEnterprise { get; set; }
        public virtual DbSet<InterestedPlatformArticle> InterestedPlatformArticle { get; set; }
        public virtual DbSet<LoginInformation> LoginInformation { get; set; }
        public virtual DbSet<Platform> Platform { get; set; }
        public virtual DbSet<Reply> Reply { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Vacancy> Vacancy { get; set; }
        public virtual DbSet<VacancySkill> VacancySkill { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AptitudeTest>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.Property(e => e.Question).HasMaxLength(100);
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.Property(e => e.ArticleContent).HasMaxLength(1000);

                entity.Property(e => e.Img)
                    .HasMaxLength(100)
                    .HasColumnName("img");

                entity.Property(e => e.Keyword).HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("date");
            });

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.Property(e => e.Account).HasMaxLength(12);

                entity.Property(e => e.Address).HasMaxLength(30);

                entity.Property(e => e.Autobiography).HasMaxLength(700);

                entity.Property(e => e.Birth).HasColumnType("date");

                entity.Property(e => e.Cellphone).HasMaxLength(10);

                entity.Property(e => e.Education).HasMaxLength(500);

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.IdCard).HasMaxLength(10);

                entity.Property(e => e.Img).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(10);

                entity.Property(e => e.Password).HasMaxLength(12);

                entity.Property(e => e.Schoolname).HasMaxLength(30);

                entity.Property(e => e.Status).HasMaxLength(30);

                entity.Property(e => e.Workexname).HasMaxLength(30);

                entity.Property(e => e.Workexperience).HasMaxLength(500);
            });

            modelBuilder.Entity<CandidateCv>(entity =>
            {
                entity.ToTable("CandidateCV");

                entity.Property(e => e.CandidateCvid).HasColumnName("CandidateCVId");

                entity.Property(e => e.Cvid).HasColumnName("CVId");

                entity.Property(e => e.Cvsource)
                    .HasMaxLength(100)
                    .HasColumnName("CVSource");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Addedtime).HasColumnType("date");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.CourseImg).HasMaxLength(200);

                entity.Property(e => e.CourseIntro).HasMaxLength(1000);

                entity.Property(e => e.CourseName).HasMaxLength(50);

                entity.Property(e => e.CourseReqire).HasMaxLength(1000);

                entity.Property(e => e.CourseVideo).HasMaxLength(100);

                entity.Property(e => e.Keyword)
                    .HasMaxLength(500)
                    .HasColumnName("keyword");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            });

            modelBuilder.Entity<CourseDetail>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.SkillId })
                    .HasName("PK__CourseDe__A4D778BF68D4D8C0");
            });

            modelBuilder.Entity<CourseOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.Property(e => e.Buyingtime).HasColumnType("date");
            });

            modelBuilder.Entity<Cv>(entity =>
            {
                entity.ToTable("CV");

                entity.Property(e => e.Cvid).HasColumnName("CVId");

                entity.Property(e => e.Img).HasMaxLength(100);

                entity.Property(e => e.Source).HasMaxLength(100);
            });

            modelBuilder.Entity<Enterprise>(entity =>
            {
                entity.Property(e => e.Account).HasMaxLength(12);

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.ContactPhone).HasMaxLength(10);

                entity.Property(e => e.Email).HasMaxLength(20);

                entity.Property(e => e.Employee)
                    .HasMaxLength(10)
                    .HasColumnName("employee");

                entity.Property(e => e.Fax).HasMaxLength(10);

                entity.Property(e => e.Img)
                    .HasMaxLength(100)
                    .HasColumnName("img");

                entity.Property(e => e.Info).HasMaxLength(200);

                entity.Property(e => e.Password).HasMaxLength(12);

                entity.Property(e => e.Principal).HasMaxLength(10);

                entity.Property(e => e.Telephone).HasMaxLength(10);

                entity.Property(e => e.UniformNumbers).HasMaxLength(10);

                entity.Property(e => e.Welfare).HasMaxLength(500);
            });

            modelBuilder.Entity<Interest>(entity =>
            {
                entity.Property(e => e.CandidateId).HasColumnName("candidateId");

                entity.Property(e => e.EnterpriseId).HasColumnName("enterpriseId");

                entity.Property(e => e.InterestStatus).HasColumnName("interestStatus");

                entity.Property(e => e.VacancyId).HasColumnName("vacancyId");
            });

            modelBuilder.Entity<InterestedArticle>(entity =>
            {
                entity.HasKey(e => new { e.CandidateId, e.ArticleId })
                    .HasName("PK_InterestedArticle_1");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<InterestedCourse>(entity =>
            {
                entity.HasKey(e => new { e.CandidateId, e.CourseId })
                    .HasName("PK_InterestedCourse_1");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<InterestedCv>(entity =>
            {
                entity.HasKey(e => new { e.CandidateId, e.Cvid })
                    .HasName("PK_InterestedCV_1");

                entity.ToTable("InterestedCV");

                entity.Property(e => e.Cvid).HasColumnName("CVId");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<InterestedEnterprise>(entity =>
            {
                entity.HasKey(e => new { e.CandidateId, e.EnterpriseId })
                    .HasName("PK_InterestedEnterprise_1");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<InterestedPlatformArticle>(entity =>
            {
                entity.HasKey(e => new { e.CandidateId, e.PlatformArticleId });

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<LoginInformation>(entity =>
            {
                entity.Property(e => e.Account).HasMaxLength(15);

                entity.Property(e => e.Email).HasMaxLength(20);

                entity.Property(e => e.Password).HasMaxLength(15);

                entity.Property(e => e.Phone).HasMaxLength(10);

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Platform>(entity =>
            {
                entity.HasKey(e => e.ArticleId);

                entity.Property(e => e.ArticleName).HasMaxLength(25);

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.Property(e => e.ReplyId).ValueGeneratedNever();

                entity.Property(e => e.ArticleName).HasMaxLength(10);

                entity.Property(e => e.ReplyTime).HasColumnType("date");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.Property(e => e.AnswerTime).HasColumnType("date");

                entity.Property(e => e.Result1)
                    .HasMaxLength(500)
                    .HasColumnName("Result");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.SkillName).HasMaxLength(50);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.Categories).HasMaxLength(30);

                entity.Property(e => e.EntryTime).HasColumnType("date");

                entity.Property(e => e.Experience).HasMaxLength(100);

                entity.Property(e => e.Img)
                    .HasMaxLength(100)
                    .HasColumnName("img");

                entity.Property(e => e.Intro).HasMaxLength(1000);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Vacancy>(entity =>
            {
                entity.Property(e => e.Category).HasMaxLength(10);

                entity.Property(e => e.Shift).HasMaxLength(20);

                entity.Property(e => e.Updatetime).HasColumnType("date");

                entity.Property(e => e.WorkContent).HasMaxLength(1000);

                entity.Property(e => e.WorkName).HasMaxLength(100);

                entity.Property(e => e.WorkPlace).HasMaxLength(100);

                entity.Property(e => e.WorkReqire).HasMaxLength(1000);

                entity.Property(e => e.WorkTime).HasMaxLength(50);
            });

            modelBuilder.Entity<VacancySkill>(entity =>
            {
                entity.HasKey(e => new { e.VacancyId, e.NeedSkillId })
                    .HasName("PK__VacancyS__81F22C8A1A5BBD82");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}