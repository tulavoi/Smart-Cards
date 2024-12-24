using SmartCards.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCards.Models
{
    [Table("Folders")]
    public class Folder
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
		public int UserId { get; set; }
        public AppUser? User { get; set; }
        public List<CourseFolder> FolderDecks { get; set; } = new List<CourseFolder>();
    }
}
