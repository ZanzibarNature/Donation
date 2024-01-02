namespace Domain
{
    public class Donation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Amount { get; set; }
        public int ArticleId { get; set; }
    }
}