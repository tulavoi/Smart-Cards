using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCards.Models;

namespace SmartCards.Areas.Identity.Data.EntityConfigurations
{
	public class CoursePermissionConfiguration : IEntityTypeConfiguration<CoursePermission>
	{
		public void Configure(EntityTypeBuilder<CoursePermission> builder)
		{
			// Khai báo key cho CoursePermission
			builder.HasKey(x => new
			{
				x.CourseId,
				x.EditPermissionId,
				x.ViewPermissionId,
			});

			builder.HasOne(x => x.Course)
			 .WithMany()
			 .HasForeignKey(x => x.CourseId)
			 .OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(x => x.ViewPermission)
			 .WithMany()
			 .HasForeignKey(x => x.ViewPermissionId)
			 .OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(x => x.EditPermission)
			 .WithMany()
			 .HasForeignKey(x => x.EditPermissionId)
			 .OnDelete(DeleteBehavior.Restrict);
		}
	}
}
