using Azure;
using Azure.Data.Tables;

namespace PublishDonationMessageOntoQueue.Domain
{
    public class Donation : ITableEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Amount { get; set; }
        public int ArticleId { get; set; }
        public string? PartitionKey { get; set; }
        public string? RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}