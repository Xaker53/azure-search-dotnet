namespace CodeFirst.Models
{
    public class History
    {
        public Guid HistoryId { get; set; } = Guid.NewGuid();
        public string HistoryText { get; set; }

        public User User { get; set; }
    }
}
