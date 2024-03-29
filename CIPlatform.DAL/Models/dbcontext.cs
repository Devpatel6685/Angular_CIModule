using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CIPlatform.DAL.Models
{
    public partial class dbcontext : DbContext
    {
        public dbcontext()
        {
        }

        public dbcontext(DbContextOptions<dbcontext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Banner> Banners { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<CmsPage> CmsPages { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<FavouriteMission> FavouriteMissions { get; set; } = null!;
        public virtual DbSet<GoalMission> GoalMissions { get; set; } = null!;
        public virtual DbSet<Mission> Missions { get; set; } = null!;
        public virtual DbSet<MissionApplication> MissionApplications { get; set; } = null!;
        public virtual DbSet<MissionMedium> MissionMedia { get; set; } = null!;
        public virtual DbSet<MissionRating> MissionRatings { get; set; } = null!;
        public virtual DbSet<MissionSkill> MissionSkills { get; set; } = null!;
        public virtual DbSet<MissionTheme> MissionThemes { get; set; } = null!;
        public virtual DbSet<ResetPassword> ResetPasswords { get; set; } = null!;
        public virtual DbSet<Skill> Skills { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=PCA33\\SQL2016;Initial Catalog=CIPLATFORM;User ID=sa;Password=Tatva@123;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("ADMIN");

                entity.Property(e => e.AdminId).HasColumnName("ADMIN_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETED_AT");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.Password)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_AT");
            });

            modelBuilder.Entity<Banner>(entity =>
            {
                entity.ToTable("BANNER");

                entity.Property(e => e.BannerId).HasColumnName("BANNER_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETED_AT");

                entity.Property(e => e.Image)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.SortOrder).HasColumnName("SORT_ORDER");

                entity.Property(e => e.Text)
                    .IsUnicode(false)
                    .HasColumnName("TEXT");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_AT");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("CITY");

                entity.Property(e => e.CityId).HasColumnName("CITY_ID");

                entity.Property(e => e.CountryId).HasColumnName("COUNTRY_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETED_AT");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_AT");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CITY__COUNTRY_ID__5812160E");
            });

            modelBuilder.Entity<CmsPage>(entity =>
            {
                entity.ToTable("CMS_PAGE");

                entity.Property(e => e.CmsPageId).HasColumnName("CMS_PAGE_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETED_AT");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Slug)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SLUG");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_AT");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("COMMENT");

                entity.Property(e => e.CommentId).HasColumnName("COMMENT_ID");

                entity.Property(e => e.ApprovalStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APPROVAL_STATUS");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETED_AT");

                entity.Property(e => e.MissionId).HasColumnName("MISSION_ID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.MissionId)
                    .HasConstraintName("FK__COMMENT__MISSION__0D7A0286");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__COMMENT__USER_ID__0E6E26BF");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("COUNTRY");

                entity.Property(e => e.CountryId).HasColumnName("COUNTRY_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETED_AT");

                entity.Property(e => e.Iso)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("ISO");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_AT");
            });

            modelBuilder.Entity<FavouriteMission>(entity =>
            {
                entity.ToTable("FAVOURITE_MISSION");

                entity.Property(e => e.FavouriteMissionId).HasColumnName("FAVOURITE_MISSION_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETED_AT");

                entity.Property(e => e.MissionId).HasColumnName("MISSION_ID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.FavouriteMissions)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FAVOURITE__MISSI__08B54D69");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FavouriteMissions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FAVOURITE__USER___09A971A2");
            });

            modelBuilder.Entity<GoalMission>(entity =>
            {
                entity.ToTable("GOAL_MISSION");

                entity.Property(e => e.GoalMissionId).HasColumnName("GOAL_MISSION_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETED_AT");

                entity.Property(e => e.GoalObjectiveText)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GOAL_OBJECTIVE_TEXT");

                entity.Property(e => e.GoalValue).HasColumnName("GOAL_VALUE");

                entity.Property(e => e.MissionId).HasColumnName("MISSION_ID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_AT");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.GoalMissions)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GOAL_MISS__MISSI__00200768");
            });

            modelBuilder.Entity<Mission>(entity =>
            {
                entity.ToTable("MISSION");

                entity.Property(e => e.MissionId).HasColumnName("MISSION_ID");

                entity.Property(e => e.Availability)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AVAILABILITY");

                entity.Property(e => e.CityId).HasColumnName("CITY_ID");

                entity.Property(e => e.CountryId).HasColumnName("COUNTRY_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETED_AT");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.MissionType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MISSION_TYPE");

                entity.Property(e => e.OrganizationName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ORGANIZATION_NAME");

                entity.Property(e => e.ShortDescription)
                    .IsUnicode(false)
                    .HasColumnName("SHORT_DESCRIPTION");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.ThemeId).HasColumnName("THEME_ID");

                entity.Property(e => e.Title)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_AT");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Missions)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MISSION__CITY_ID__6477ECF3");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Missions)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MISSION__COUNTRY__656C112C");

                entity.HasOne(d => d.Theme)
                    .WithMany(p => p.Missions)
                    .HasForeignKey(d => d.ThemeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MISSION__THEME_I__6383C8BA");
            });

            modelBuilder.Entity<MissionApplication>(entity =>
            {
                entity.ToTable("MISSION_APPLICATION");

                entity.Property(e => e.MissionApplicationId).HasColumnName("MISSION_APPLICATION_ID");

                entity.Property(e => e.AppliedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("APPLIED_AT");

                entity.Property(e => e.ApprovalStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APPROVAL_STATUS");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETED_AT");

                entity.Property(e => e.MissionId).HasColumnName("MISSION_ID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.MissionApplications)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MISSION_A__MISSI__7B5B524B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MissionApplications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MISSION_A__USER___7C4F7684");
            });

            modelBuilder.Entity<MissionMedium>(entity =>
            {
                entity.HasKey(e => e.MissionMediaId)
                    .HasName("PK__MISSION___E70AA8B7FA9E09E3");

                entity.ToTable("MISSION_MEDIA");

                entity.Property(e => e.MissionMediaId).HasColumnName("MISSION_MEDIA_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETED_AT");

                entity.Property(e => e.MediaName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MEDIA_NAME");

                entity.Property(e => e.MediaPath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MEDIA_PATH");

                entity.Property(e => e.MediaType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MEDIA_TYPE");

                entity.Property(e => e.MissionId).HasColumnName("MISSION_ID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_AT");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.MissionMedia)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MISSION_M__MISSI__72C60C4A");
            });

            modelBuilder.Entity<MissionRating>(entity =>
            {
                entity.ToTable("MISSION_RATING");

                entity.Property(e => e.MissionRatingId).HasColumnName("MISSION_RATING_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETED_AT");

                entity.Property(e => e.MissionId).HasColumnName("MISSION_ID");

                entity.Property(e => e.Rating).HasColumnName("RATING");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.MissionRatings)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MISSION_R__MISSI__6E01572D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MissionRatings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MISSION_R__USER___6EF57B66");
            });

            modelBuilder.Entity<MissionSkill>(entity =>
            {
                entity.ToTable("MISSION_SKILL");

                entity.Property(e => e.MissionSkillId).HasColumnName("MISSION_SKILL_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETED_AT");

                entity.Property(e => e.MissionId).HasColumnName("MISSION_ID");

                entity.Property(e => e.SkillId).HasColumnName("SKILL_ID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_AT");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.MissionSkills)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MISSION_S__MISSI__693CA210");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.MissionSkills)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MISSION_S__SKILL__6A30C649");
            });

            modelBuilder.Entity<MissionTheme>(entity =>
            {
                entity.ToTable("MISSION_THEME");

                entity.Property(e => e.MissionThemeId).HasColumnName("MISSION_THEME_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETED_AT");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_AT");
            });

            modelBuilder.Entity<ResetPassword>(entity =>
            {
                entity.ToTable("ResetPassword");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Token)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ResetPasswords)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ResetPass__UserI__4BAC3F29");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("SKILL");

                entity.Property(e => e.SkillId).HasColumnName("SKILL_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETED_AT");

                entity.Property(e => e.SkillName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("SKILL_NAME");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_AT");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(255)
                    .HasColumnName("AVATAR");

                entity.Property(e => e.Cityid).HasColumnName("CITYID");

                entity.Property(e => e.Countryid).HasColumnName("COUNTRYID");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATEDATE");

                entity.Property(e => e.Deletedate)
                    .HasColumnType("datetime")
                    .HasColumnName("DELETEDATE");

                entity.Property(e => e.Department)
                    .HasMaxLength(255)
                    .HasColumnName("DEPARTMENT");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Employeeid)
                    .HasMaxLength(255)
                    .HasColumnName("EMPLOYEEID");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(255)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(255)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Linkedinurl)
                    .HasMaxLength(255)
                    .HasColumnName("LINKEDINURL");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phonenumber).HasColumnName("PHONENUMBER");

                entity.Property(e => e.Profiletext).HasColumnName("PROFILETEXT");

                entity.Property(e => e.Role)
                    .HasMaxLength(255)
                    .HasColumnName("ROLE");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("TITLE");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATEDATE");

                entity.Property(e => e.Whyivolunteer).HasColumnName("WHYIVOLUNTEER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
