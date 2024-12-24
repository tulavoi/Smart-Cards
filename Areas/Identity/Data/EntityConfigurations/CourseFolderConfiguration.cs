using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCards.Models;

namespace SmartCards.Areas.Identity.Data.EntityConfigurations
{
	public class CourseFolderConfiguration : IEntityTypeConfiguration<CourseFolder>
	{
		public void Configure(EntityTypeBuilder<CourseFolder> builder)
		{
			// Khai báo key cho FolderCourse
			builder.HasKey(p => new
			{
				p.CourseId,
				p.FolderId
			});

			builder.HasOne(x => x.Course)
				.WithMany(x => x.CourseFolders)
				.HasForeignKey(x => x.CourseId);

			builder.HasOne(x => x.Folder)
				.WithMany(x => x.FolderDecks)
				.HasForeignKey(x => x.FolderId);
		}
	}
}
