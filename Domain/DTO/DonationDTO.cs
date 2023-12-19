namespace Domain.DTO
{
    public class DonationDTO
    {
        int Id { get; set; }
        int UserId { get; set; }
        double Amount { get; set; }
        int ProjectId { get; set; }
    }
}
