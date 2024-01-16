using Azure;
using DonationAPI.Domain;
using DonationAPI.Domain.DTO;

namespace DonationAPI.Services.Interfaces
{
    public interface IDonationService
    {
        public Task<Donation> CreateDonationAsync(DonationDTO donationDTO);
        public Task<Donation> GetDonationByKeyAsync(string partitionKey, string rowKey);
        public Task<IList<Donation>> GetPagesOfDonationsAsync();
        public Task<Donation> UpdateDonationAsync(UpdateDonationDTO donationDTO);
        public Task<Response> DeleteDonationAsync(string partitionKey, string rowKey);
    }
}
