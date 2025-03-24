namespace API_Demo.Models
{
    public class PerformanceReview
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }  // Rating scale: 1 to 5
        public string Comments { get; set; }
        public User User { get; set; }
    }
}
