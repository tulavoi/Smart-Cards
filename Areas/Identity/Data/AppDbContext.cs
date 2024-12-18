using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCards.Areas.Identity.Data;
using static NuGet.Packaging.PackagingConstants;

namespace SmartCards.Areas.Identity.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Bỏ 'AspNet' ra khỏi tên các table
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName == null) return;
            if (tableName.StartsWith("AspNet"))
                entityType.SetTableName(tableName.Substring(6));
        }

        // Seed dữ liệu cho bảng Roles
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Name = "User", NormalizedName = "USER" }
        );

        //// Seed dữ liệu cho bảng Languages
        //builder.Entity<Language>().HasData(
        //    new Language { Id = 1, Code = "en", Name = "English", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
        //    new Language { Id = 2, Code = "fr", Name = "French", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
        //    new Language { Id = 3, Code = "de", Name = "German", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
        //    new Language { Id = 4, Code = "es", Name = "Spanish", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
        //    new Language { Id = 5, Code = "it", Name = "Italian", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
        //    new Language { Id = 6, Code = "pt", Name = "Portuguese", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
        //    new Language { Id = 7, Code = "zh", Name = "Chinese", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
        //    new Language { Id = 8, Code = "ja", Name = "Japanese", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
        //    new Language { Id = 9, Code = "ru", Name = "Russian", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
        //    new Language { Id = 10, Code = "ar", Name = "Arabic", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
        //);

        //// Khai báo key cho FolderDecks
        //builder.Entity<FolderDeck>(x => x.HasKey(p => new {
        //    p.DeckId,
        //    p.FolderId
        //}));

        //builder.Entity<FolderDeck>()
        //    .HasOne(x => x.Deck)
        //    .WithMany(x => x.FolderDecks)
        //    .HasForeignKey(x => x.DeckId);

        //builder.Entity<FolderDeck>()
        //   .HasOne(x => x.Folder)
        //   .WithMany(x => x.FolderDecks)
        //   .HasForeignKey(x => x.FolderId);
    }

    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.AvatarFileName).HasMaxLength(50);
        }
    }

    //public DbSet<Deck> Decks { get; set; }
    //public DbSet<Flashcard> Flashcards { get; set; }
    //public DbSet<Language> Languages { get; set; }
    //public DbSet<Folder> Folders { get; set; }
    //public DbSet<FolderDeck> FolderDecks { get; set; }
}
