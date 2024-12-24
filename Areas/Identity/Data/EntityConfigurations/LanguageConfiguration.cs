using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCards.Models;

namespace SmartCards.Areas.Identity.Data.EntityConfigurations
{
	public class LanguageConfiguration : IEntityTypeConfiguration<Language>
	{
		public void Configure(EntityTypeBuilder<Language> builder)
		{
			// Seed dữ liệu cho table Languages
			builder.HasData(
				new Language { Id = 1, Code = "en", Name = "English", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
				new Language { Id = 2, Code = "fr", Name = "French", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
				new Language { Id = 3, Code = "de", Name = "German", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
				new Language { Id = 4, Code = "es", Name = "Spanish", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
				new Language { Id = 5, Code = "it", Name = "Italian", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
				new Language { Id = 6, Code = "pt", Name = "Portuguese", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
				new Language { Id = 7, Code = "zh", Name = "Chinese", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
				new Language { Id = 8, Code = "ja", Name = "Japanese", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
				new Language { Id = 9, Code = "ru", Name = "Russian", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
				new Language { Id = 10, Code = "ar", Name = "Arabic", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
			);
		}
	}
}
