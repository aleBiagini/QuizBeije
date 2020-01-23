using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuizBeije.Models
{
    public partial class QuizBeijeContext : DbContext
    {
        public QuizBeijeContext()
        {
        }

        public QuizBeijeContext(DbContextOptions<QuizBeijeContext> options)
            : base(options)
        {
        }



        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Attempts> Attempts { get; set; }
        public virtual DbSet<Choices> Choices { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Quiz> Quiz { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersQuiz> UsersQuiz { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("ConnectionStringsServer=tcp:stanza6.database.windows.net,1433;Initial Catalog=QuizBeije;Persist Security Info=False;User ID=ale;Password=Sicurezza6!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answers>(entity =>
            {
                entity.HasKey(e => e.AnswerId);

                entity.Property(e => e.AnswerId).HasColumnName("AnswerID");

                entity.Property(e => e.AnswerText).IsUnicode(false);

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_Answers_Questions");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Answers_Users");
            });

            modelBuilder.Entity<Attempts>(entity =>
            {
                entity.HasKey(e => e.AttemptId);

                entity.Property(e => e.AttemptId).HasColumnName("AttemptID");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Attempts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attempts_Users");
            });

            modelBuilder.Entity<Choices>(entity =>
            {
                entity.HasKey(e => e.ChoiceId);

                entity.Property(e => e.ChoiceId).HasColumnName("ChoiceID");

                entity.Property(e => e.ChoiceText).IsUnicode(false);

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Choices)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_Choices_Questions");
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.QuestionText).IsUnicode(false);

                entity.Property(e => e.QuizId).HasColumnName("QuizID");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("FK_Questions_Quiz");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.Property(e => e.QuizId).HasColumnName("QuizID");

                entity.Property(e => e.QuizName)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilImage)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsersQuiz>(entity =>
            {
                entity.HasKey(e => e.UserQuizId)
                    .HasName("PK__Users_Qu__20FA63A791B62645");

                entity.ToTable("Users_Quiz");

                entity.Property(e => e.UserQuizId).HasColumnName("UserQuizID");

                entity.Property(e => e.QuizId).HasColumnName("QuizID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.UsersQuiz)
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quiz");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersQuiz)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
