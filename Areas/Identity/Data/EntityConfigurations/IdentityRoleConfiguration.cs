using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartCards.Areas.Identity.Data.EntityConfigurations
{
	public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
	{
		public void Configure(EntityTypeBuilder<IdentityRole> builder)
		{
			// Seed dữ liệu cho bảng Roles
			builder.HasData(
				new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
				new IdentityRole { Name = "User", NormalizedName = "USER" }
			);
		}
	}
}
