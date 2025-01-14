using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CinemaHub_DAL.Models;

public partial class CinemaHubContext : DbContext
{
    public CinemaHubContext()
    {
    }

    public CinemaHubContext(DbContextOptions<CinemaHubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<Cinema> Cinemas { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<PaymentsTable> PaymentsTables { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Showtime> Showtimes { get; set; }

    public virtual DbSet<TicketsTable> TicketsTables { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userwithcinema> Userwithcinemas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=IBRAHIM-LAPTOP\\SQLEXPRESS01;Database=CinemaHub;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.LogId);

            entity.ToTable("auditLog");

            entity.Property(e => e.LogId).HasColumnName("log_id");
            entity.Property(e => e.Action)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("action");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Cinema>(entity =>
        {
            entity.ToTable("cinema");

            entity.Property(e => e.CinemaId).HasColumnName("cinema_id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.ContactInfo).HasColumnName("contact_info");
            entity.Property(e => e.Location).HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("genres");

            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.ToTable("movies");

            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.CinemaId).HasColumnName("cinemaID");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.PosterUrl).HasColumnName("poster_url");
            entity.Property(e => e.Rating)
                .HasColumnType("decimal(2, 1)")
                .HasColumnName("rating");
            entity.Property(e => e.ReleaseDate)
                .HasMaxLength(50)
                .HasColumnName("release_date");
            entity.Property(e => e.Shortdescription)
                .HasColumnType("text")
                .HasColumnName("shortdescription");
            entity.Property(e => e.ShowTime)
                .HasMaxLength(50)
                .HasColumnName("showTime");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");

            entity.HasOne(d => d.Cinema).WithMany(p => p.Movies)
                .HasForeignKey(d => d.CinemaId)
                .HasConstraintName("FK_movies_cinema");

            entity.HasOne(d => d.Genre).WithMany(p => p.Movies)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK_movies_genres");
        });

        modelBuilder.Entity<PaymentsTable>(entity =>
        {
            entity.HasKey(e => e.PaymentId);

            entity.ToTable("payments table");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("payment_method");
            entity.Property(e => e.PaymentTime)
                .HasColumnType("datetime")
                .HasColumnName("payment_time");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.ToTable("reviews");

            entity.Property(e => e.ReviewId).HasColumnName("review_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.Rating)
                .HasColumnType("decimal(2, 1)")
                .HasColumnName("rating");
            entity.Property(e => e.ReviewText)
                .HasColumnType("text")
                .HasColumnName("review_text");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_reviews_user");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("role");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Showtime>(entity =>
        {
            entity.ToTable("showtime");

            entity.Property(e => e.ShowtimeId).HasColumnName("showtime_id");
            entity.Property(e => e.AvailableSeats).HasColumnName("available_seats");
            entity.Property(e => e.CinemaId).HasColumnName("cinema_id");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("start_time");
        });

        modelBuilder.Entity<TicketsTable>(entity =>
        {
            entity.HasKey(e => e.TicketId);

            entity.ToTable("tickets table");

            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.BookingTime)
                .HasColumnType("datetime")
                .HasColumnName("booking_time");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("price");
            entity.Property(e => e.SeatNumber)
                .HasMaxLength(50)
                .HasColumnName("seat_number");
            entity.Property(e => e.ShowtimeId).HasColumnName("showtime_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Showtime).WithMany(p => p.TicketsTables)
                .HasForeignKey(d => d.ShowtimeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tickets table_showtime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CinemaId).HasColumnName("cinema_id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Cinema).WithMany(p => p.Users)
                .HasForeignKey(d => d.CinemaId)
                .HasConstraintName("FK_user_cinema");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_role");
        });

        modelBuilder.Entity<Userwithcinema>(entity =>
        {
            entity.ToTable("userwithcinema");

            entity.Property(e => e.UserwithcinemaId).HasColumnName("userwithcinemaId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Cinema).WithMany(p => p.Userwithcinemas)
                .HasForeignKey(d => d.CinemaId)
                .HasConstraintName("FK_userwithcinema_cinema");

            entity.HasOne(d => d.User).WithMany(p => p.Userwithcinemas)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_userwithcinema_user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
