﻿using Azure;

namespace DonationAPI.Domain.DTO
{
    public class DonationDTO
    {
        public int UserId { get; set; }
        public double Amount { get; set; }
        public int ArticleId { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
