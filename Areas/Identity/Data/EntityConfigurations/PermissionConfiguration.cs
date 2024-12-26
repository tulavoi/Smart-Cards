using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCards.Models;

namespace SmartCards.Areas.Identity.Data.EntityConfigurations
{
	public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
	{
		public void Configure(EntityTypeBuilder<Permission> builder)
		{
			// Seed dữ liệu cho table Permissions
			builder.HasData(
				new Permission { Id = 1, Name = "Mọi người", Description = "Mọi người đều có thể sử dụng học phần này", IsEdit = false },
				new Permission { Id = 2, Name = "Người có mật khẩu", Description = "Chỉ những người có mật khẩu mới có thể sử dụng học phần này", IsEdit = false },
				new Permission { Id = 3, Name = "Chỉ tôi", Description = "Chỉ tôi mới có thể sử dụng học phần này", IsEdit = false },
				new Permission { Id = 4, Name = "Chỉ tôi", Description = "Chỉ tôi mới có thể chỉnh sửa học phần này", IsEdit = true },
				new Permission { Id = 5, Name = "Người có mật khẩu", Description = "Chỉ những người có mật khẩu mới có thể chỉnh sửa học phần này", IsEdit = true }
			);
        }
	}
}
