namespace CodeFirst.Models
{
    public class History
    {
        public int HistoryId { get; set; }
        public string HistoryText { get; set; }

        public User User { get; set; }
    }
}
