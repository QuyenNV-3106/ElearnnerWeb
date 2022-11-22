using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ELearnerApi.Models
{
    public partial class ElearnnerDBContext : DbContext
    {
        public ElearnnerDBContext()
        {
        }

        public ElearnnerDBContext(DbContextOptions<ElearnnerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Vocabulary> Vocabularies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ElearnnerDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.Role)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("role");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.TopicId).HasColumnName("topicID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("userName");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("FK__Accounts__topicI__2C3393D0");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Duration)
                    .HasColumnType("datetime")
                    .HasColumnName("duration");

                entity.Property(e => e.Kind)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("kind");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasColumnName("status");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name"); 

                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("time");
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("courseID");

                entity.Property(e => e.DayBilling)
                    .HasColumnType("datetime")
                    .HasColumnName("dayBilling");

                entity.Property(e => e.NumberCard).HasColumnName("numberCard");

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Receipts__course__2D27B809");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Receipts__userID__2E1BDC42");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ImgUrl)
                    .IsRequired()
                    .HasColumnName("imgURL");

                entity.Property(e => e.Kind)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("kind");

                entity.Property(e => e.MeetUrl).HasColumnName("meetURL");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasColumnName("status");

                entity.Property(e => e.SubTitle)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("subTitle");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Vocabulary>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.English)
                    .HasMaxLength(500)
                    .HasColumnName("english");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.Vietnamese)
                    .HasMaxLength(500)
                    .HasColumnName("vietnamese");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Vocabularies)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Vocabular__userI__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
