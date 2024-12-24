using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCards.Areas.Identity.Data;
using SmartCards.Areas.Identity.Data.EntityConfigurations;
using SmartCards.Models;
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

        this.RemoveAspNetPrefix(builder);

        builder.ApplyConfiguration(new AppUserConfiguration());

		builder.ApplyConfiguration(new IdentityRoleConfiguration());

		builder.ApplyConfiguration(new LanguageConfiguration());

		builder.ApplyConfiguration(new PermissionConfiguration());

		builder.ApplyConfiguration(new CourseFolderConfiguration());

		builder.ApplyConfiguration(new CoursePermissionConfiguration());

	}

	private void RemoveAspNetPrefix(ModelBuilder builder)
	{
		// Bỏ 'AspNet' ra khỏi tên các table
		foreach (var entityType in builder.Model.GetEntityTypes())
		{
			var tableName = entityType.GetTableName();
			if (tableName == null) return;
			if (tableName.StartsWith("AspNet"))
				entityType.SetTableName(tableName.Substring(6));
		}
	}

	public DbSet<Course> Courses { get; set; }
    public DbSet<Flashcard> Flashcards { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Folder> Folders { get; set; }
    public DbSet<CourseFolder> FolderDecks { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<CoursePermission> CoursePermissions { get; set; }
}
