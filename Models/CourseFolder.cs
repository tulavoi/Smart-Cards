using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCards.Models
{
    [Table("CourseFolder")]
    public class CourseFolder
    {
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public int FolderId { get; set; }
        public Folder? Folder { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
	}
}
