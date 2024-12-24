using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCards.Models
{
	[Table("Permissions")]
	public class Permission
	{
		public int Id { get; set; }
		[MaxLength(100)]
		[Required]
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		[MaxLength(50)]
		public bool IsEdit { get; set; }
	}
}
