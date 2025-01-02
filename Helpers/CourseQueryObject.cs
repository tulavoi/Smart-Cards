namespace api.Helpers
{
    public class CourseQueryObject
    {
        public string? SortBy { get; set; }
        public bool IsDecsending { get; set; } = false;
        public int MaxItem { get; set; }
    }
}
