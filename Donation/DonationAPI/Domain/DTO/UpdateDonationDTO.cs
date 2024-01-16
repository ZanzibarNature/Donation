using Azure;

namespace DonationAPI.Domain.DTO
{
    public class UpdateDonationDTO : DonationDTO
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
