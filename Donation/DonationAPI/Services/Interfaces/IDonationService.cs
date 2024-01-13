using Azure;
using DonationAPI.Domain;
using DonationAPI.Domain.DTO;

namespace DonationAPI.Services.Interfaces
{
    public interface IDonationService
    {
        public Task<Donation> StoreDonationAsync(DonationDTO donationDTO);
        public Task<Donation> GetDonationByKeyAsync(string partitionKey, string rowKey);
        public Task<IList<Donation>> GetAllDonationsAsync();
        public Task<Donation> UpdateDonationAsync(DonationDTO donationDTO);
        public Task<Response> DeleteDonationAsync(string partitionKey, string rowKey);
    }
}
