using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using QuizWebAPI;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuizWebAPI
{
    public partial class db_a848c4_quizContext : DbContext
    {
        public db_a848c4_quizContext()
        {
        }

        public db_a848c4_quizContext(DbContextOptions<db_a848c4_quizContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Achievement> Achievement { get; set; }
        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Chat> Chat { get; set; }
        public virtual DbSet<ChatOfUser> ChatOfUser { get; set; }
        public virtual DbSet<EmailPassword> EmailPassword { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<QuizItem> QuizItem { get; set; }
        public virtual DbSet<Score> Score { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAchievement> UserAchievement { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //http://go.microsoft.com/fwlink/?LinkId=723263
                //optionsBuilder.UseLazyLoadingProxies().UseSqlServer();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.Property(e => e.Text).HasMaxLength(250);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answer_Question");
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.CreatorUser)
                    .WithMany(p => p.CreatedChats)
                    .HasForeignKey(d => d.CreatorUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chat_User");
            });

            modelBuilder.Entity<ChatOfUser>(entity =>
            {
                entity.HasOne(d => d.Chat)
                    .WithMany(p => p.ChatOfUsers)
                    .HasForeignKey(d => d.ChatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChatOfUse__ChatI__2C3393D0");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ChatOfUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChatOfUse__UserI__2D27B809");
            });

            modelBuilder.Entity<EmailPassword>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Text).HasMaxLength(350);

                entity.HasOne(d => d.Chat)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ChatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Messages__ChatId__30F848ED");

                entity.HasOne(d => d.SenderUser)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.SenderUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Messages__Sender__300424B4");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Text).HasMaxLength(250);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notification_User");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Text).HasMaxLength(150);

                entity.HasOne(d => d.QuizItem)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuizItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Questions__QuizI__36B12243");
            });

            modelBuilder.Entity<QuizItem>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.CreatorUser)
                    .WithMany(p => p.QuizItems)
                    .HasForeignKey(d => d.CreatorUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__QuizItems__Creat__33D4B598");
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.HasOne(d => d.QuizItem)
                    .WithMany(p => p.Scores)
                    .HasForeignKey(d => d.QuizItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Scores__QuizItem__398D8EEE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Scores)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Scores__UserId__3A81B327");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Hobby).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Organization).HasMaxLength(200);

                entity.HasOne(d => d.EmailPassword)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.EmailPasswordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__EmailPass__267ABA7A");
            });

            modelBuilder.Entity<UserAchievement>(entity =>
            {
                entity.HasOne(d => d.Achievement)
                    .WithMany(p => p.UserAchievements)
                    .HasForeignKey(d => d.AchievementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAchievement_Achievement");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAchievements)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAchievement_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
