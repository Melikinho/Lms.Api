namespace Lms.Core.Entities
{
    public class Course
    {
#nullable disable
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate = DateTime.Now;

        public ICollection<Module> Modules { get; set; } = new List<Module>();

    }
}