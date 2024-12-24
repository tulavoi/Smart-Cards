using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCards.Models
{
	[Table("CoursePermissions")]
	public class CoursePermission
	{
		public int CourseId { get; set; }
		public Course Course { get; set; }
		public int ViewPermissionId { get; set; }
		public Permission ViewPermission { get; set; }
		public int EditPermissionId { get; set; }
		public Permission EditPermission { get; set; }
	}
}
