using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models.Movies;

public partial class MoviesContext : DbContext
{
    public MoviesContext()
    {
    }

    public MoviesContext(DbContextOptions<MoviesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Keyword> Keywords { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<LanguageRole> LanguageRoles { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieCast> MovieCasts { get; set; }

    public virtual DbSet<MovieCompany> MovieCompanies { get; set; }

    public virtual DbSet<MovieCrew> MovieCrews { get; set; }

    public virtual DbSet<MovieGenre> MovieGenres { get; set; }

    public virtual DbSet<MovieKeyword> MovieKeywords { get; set; }

    public virtual DbSet<MovieLanguage> MovieLanguages { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<ProductionCompany> ProductionCompanies { get; set; }

    public virtual DbSet<ProductionCountry> ProductionCountries { get; set; }
/*
    //commented due to connecting context in appsettings.json
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=/Users/kacper.glowczyk/data/movies.db");
*/
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("country");

            entity.Property(e => e.CountryId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("country_id");
            entity.Property(e => e.CountryIsoCode)
                .HasDefaultValueSql("NULL")
                .HasColumnName("country_iso_code");
            entity.Property(e => e.CountryName)
                .HasDefaultValueSql("NULL")
                .HasColumnName("country_name");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("department");

            entity.Property(e => e.DepartmentId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("department_id");
            entity.Property(e => e.DepartmentName)
                .HasDefaultValueSql("NULL")
                .HasColumnName("department_name");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("gender");

            entity.Property(e => e.GenderId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("gender_id");
            entity.Property(e => e.Gender1)
                .HasDefaultValueSql("NULL")
                .HasColumnName("gender");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("genre");

            entity.Property(e => e.GenreId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("genre_id");
            entity.Property(e => e.GenreName)
                .HasDefaultValueSql("NULL")
                .HasColumnName("genre_name");
        });

        modelBuilder.Entity<Keyword>(entity =>
        {
            entity.ToTable("keyword");

            entity.Property(e => e.KeywordId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("keyword_id");
            entity.Property(e => e.KeywordName)
                .HasDefaultValueSql("NULL")
                .HasColumnType("varchar(100)")
                .HasColumnName("keyword_name");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.ToTable("language");

            entity.Property(e => e.LanguageId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("language_id");
            entity.Property(e => e.LanguageCode)
                .HasDefaultValueSql("NULL")
                .HasColumnName("language_code");
            entity.Property(e => e.LanguageName)
                .HasDefaultValueSql("NULL")
                .HasColumnName("language_name");
        });

        modelBuilder.Entity<LanguageRole>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.ToTable("language_role");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("role_id");
            entity.Property(e => e.LanguageRole1)
                .HasDefaultValueSql("NULL")
                .HasColumnName("language_role");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.ToTable("movie");

            entity.Property(e => e.MovieId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("movie_id");
            entity.Property(e => e.Budget)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("budget");
            entity.Property(e => e.Homepage)
                .HasDefaultValueSql("NULL")
                .HasColumnName("homepage");
            entity.Property(e => e.MovieStatus)
                .HasDefaultValueSql("NULL")
                .HasColumnName("movie_status");
            entity.Property(e => e.Overview)
                .HasDefaultValueSql("NULL")
                .HasColumnName("overview");
            entity.Property(e => e.Popularity)
                .HasDefaultValueSql("NULL")
                .HasColumnName("popularity");
            entity.Property(e => e.ReleaseDate)
                .HasDefaultValueSql("NULL")
                .HasColumnType("DATE")
                .HasColumnName("release_date");
            entity.Property(e => e.Revenue)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("revenue");
            entity.Property(e => e.Runtime)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("runtime");
            entity.Property(e => e.Tagline)
                .HasDefaultValueSql("NULL")
                .HasColumnName("tagline");
            entity.Property(e => e.Title)
                .HasDefaultValueSql("NULL")
                .HasColumnName("title");
            entity.Property(e => e.VoteAverage)
                .HasDefaultValueSql("NULL")
                .HasColumnName("vote_average");
            entity.Property(e => e.VoteCount)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("vote_count");
            
            // Configure relationships
            entity.HasMany(e => e.MovieCasts)
                .WithOne(e => e.Movie)
                .HasForeignKey(e => e.MovieId);

            entity.HasMany(e => e.MovieGenres)
                .WithOne(e => e.Movie)
                .HasForeignKey(e => e.MovieId);

            entity.HasMany(e => e.MovieKeywords)
                .WithOne(e => e.Movie)
                .HasForeignKey(e => e.MovieId);

            entity.HasMany(e => e.MovieCompanies)
                .WithOne(e => e.Movie)
                .HasForeignKey(e => e.MovieId);

            entity.HasMany(e => e.MovieLanguages)
                .WithOne(e => e.Movie)
                .HasForeignKey(e => e.MovieId);

            entity.HasMany(e => e.ProductionCountries)
                .WithOne(e => e.Movie)
                .HasForeignKey(e => e.MovieId);
        });

modelBuilder.Entity<MovieCast>(entity =>
{
    entity.ToTable("movie_cast");
    entity.HasKey(mc => new { mc.MovieId, mc.PersonId, mc.GenderId });

    entity.Property(e => e.CastOrder).HasColumnName("cast_order");
    entity.Property(e => e.CharacterName).HasColumnName("character_name");
    entity.Property(e => e.GenderId).HasColumnName("gender_id");
    entity.Property(e => e.MovieId).HasColumnName("movie_id");
    entity.Property(e => e.PersonId).HasColumnName("person_id");

    entity.HasOne(mc => mc.Gender).WithMany().HasForeignKey(mc => mc.GenderId);
    entity.HasOne(mc => mc.Movie).WithMany(m => m.MovieCasts).HasForeignKey(mc => mc.MovieId);
    entity.HasOne(mc => mc.Person).WithMany().HasForeignKey(mc => mc.PersonId);
});

modelBuilder.Entity<MovieCompany>(entity =>
{
    entity.ToTable("movie_company");
    entity.HasKey(mc => new { mc.MovieId, mc.CompanyId });

    entity.Property(e => e.CompanyId).HasColumnName("company_id");
    entity.Property(e => e.MovieId).HasColumnName("movie_id");

    entity.HasOne(mc => mc.Company).WithMany().HasForeignKey(mc => mc.CompanyId);
    entity.HasOne(mc => mc.Movie).WithMany(m => m.MovieCompanies).HasForeignKey(mc => mc.MovieId);
});


modelBuilder.Entity<MovieGenre>(entity =>
{
    entity.ToTable("movie_genres");
    entity.HasKey(mg => new { mg.MovieId, mg.GenreId });

    entity.Property(e => e.GenreId).HasColumnName("genre_id");
    entity.Property(e => e.MovieId).HasColumnName("movie_id");

    entity.HasOne(mg => mg.Genre).WithMany().HasForeignKey(mg => mg.GenreId);
    entity.HasOne(mg => mg.Movie).WithMany(m => m.MovieGenres).HasForeignKey(mg => mg.MovieId);
});

modelBuilder.Entity<MovieKeyword>(entity =>
{
    entity.ToTable("movie_keywords");
    entity.HasKey(mk => new { mk.MovieId, mk.KeywordId });

    entity.Property(e => e.KeywordId).HasColumnName("keyword_id");
    entity.Property(e => e.MovieId).HasColumnName("movie_id");

    entity.HasOne(mk => mk.Keyword).WithMany().HasForeignKey(mk => mk.KeywordId);
    entity.HasOne(mk => mk.Movie).WithMany(m => m.MovieKeywords).HasForeignKey(mk => mk.MovieId);
});


modelBuilder.Entity<MovieLanguage>(entity =>
{
    entity.ToTable("movie_languages");
    entity.HasKey(ml => new { ml.MovieId, ml.LanguageId, ml.LanguageRoleId });

    entity.Property(e => e.LanguageId).HasColumnName("language_id");
    entity.Property(e => e.LanguageRoleId).HasColumnName("language_role_id");
    entity.Property(e => e.MovieId).HasColumnName("movie_id");

    entity.HasOne(ml => ml.Language).WithMany().HasForeignKey(ml => ml.LanguageId);
    entity.HasOne(ml => ml.LanguageRole).WithMany().HasForeignKey(ml => ml.LanguageRoleId);
    entity.HasOne(ml => ml.Movie).WithMany(m => m.MovieLanguages).HasForeignKey(ml => ml.MovieId);
});

modelBuilder.Entity<ProductionCountry>(entity =>
{
    entity.ToTable("production_country");
    entity.HasKey(pc => new { pc.MovieId, pc.CountryId });

    entity.Property(e => e.CountryId).HasColumnName("country_id");
    entity.Property(e => e.MovieId).HasColumnName("movie_id");

    entity.HasOne(pc => pc.Country).WithMany().HasForeignKey(pc => pc.CountryId);
    entity.HasOne(pc => pc.Movie).WithMany(m => m.ProductionCountries).HasForeignKey(pc => pc.MovieId);
});

        modelBuilder.Entity<MovieCrew>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("movie_crew");

            entity.Property(e => e.DepartmentId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("department_id");
            entity.Property(e => e.Job)
                .HasDefaultValueSql("NULL")
                .HasColumnName("job");
            entity.Property(e => e.MovieId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("movie_id");
            entity.Property(e => e.PersonId)
                .HasDefaultValueSql("NULL")
                .HasColumnType("INT")
                .HasColumnName("person_id");

            entity.HasOne(d => d.Department).WithMany().HasForeignKey(d => d.DepartmentId);

            entity.HasOne(d => d.Movie).WithMany().HasForeignKey(d => d.MovieId);

            entity.HasOne(d => d.Person).WithMany().HasForeignKey(d => d.PersonId);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("person");

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("person_id");
            entity.Property(e => e.PersonName)
                .HasDefaultValueSql("NULL")
                .HasColumnName("person_name");
        });

        modelBuilder.Entity<ProductionCompany>(entity =>
        {
            entity.HasKey(e => e.CompanyId);

            entity.ToTable("production_company");

            entity.Property(e => e.CompanyId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("company_id");
            entity.Property(e => e.CompanyName)
                .HasDefaultValueSql("NULL")
                .HasColumnName("company_name");
        });

        

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
