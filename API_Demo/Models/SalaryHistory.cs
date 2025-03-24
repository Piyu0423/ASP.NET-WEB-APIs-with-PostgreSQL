namespace API_Demo.Models
{
    public class SalaryHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal SalaryAmount { get; set; }
        public DateTime EffectiveDate { get; set; }
        public User User { get; set; }
    }
}
