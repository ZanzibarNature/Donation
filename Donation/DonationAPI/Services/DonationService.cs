using Azure;
using DonationAPI.DAL.Repos.Interfaces;
using DonationAPI.Domain;
using DonationAPI.Domain.DTO;
using DonationAPI.Services.Interfaces;

namespace DonationAPI.Services
{
    public class DonationService : IDonationService
    {
        private readonly IDonationRepository<Donation> _donationRepository;

        public DonationService(IDonationRepository<Donation> donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<Response> DeleteDonationAsync(string partitionKey, string rowKey)
        {
            return await _donationRepository.DeleteDonationAsync(partitionKey, rowKey);
        }

        public async Task<IList<Donation>> GetAllDonationsAsync()
        {
            return await _donationRepository.GetAllDonationsAsync();
        }

        public async Task<Donation> GetDonationByKeyAsync(string partitionKey, string rowKey)
        {
            return await _donationRepository.GetDonationByIdAsync(partitionKey, rowKey);
        }

        public async Task<Donation> StoreDonationAsync(DonationDTO donationDTO)
        {
            Donation donation = new Donation
            {
                PartitionKey = "Donation",
                RowKey = Guid.NewGuid().ToString(),
                Amount = donationDTO.Amount,
                ArticleId = donationDTO.ArticleId,
                UserId = donationDTO.UserId
            };

            await _donationRepository.UpsertDonationAsync(donation);
            return donation;
        }

        public async Task<Donation> UpdateDonationAsync(DonationDTO donationDTO)
        {
            Donation donation = new Donation
            {
                PartitionKey = "Donation",
                RowKey = Guid.NewGuid().ToString(),
                ETag = donationDTO.ETag,
                Amount = donationDTO.Amount,
                ArticleId = donationDTO.ArticleId,
                UserId = donationDTO.UserId
            };

            await _donationRepository.UpsertDonationAsync(donation);
            return donation;
        }
    }
}