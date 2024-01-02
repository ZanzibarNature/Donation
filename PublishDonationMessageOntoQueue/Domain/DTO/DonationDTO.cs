namespace PublishDonationMessageOntoQueue.Domain.DTO
{
    public class DonationDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Amount { get; set; }
    }
}
