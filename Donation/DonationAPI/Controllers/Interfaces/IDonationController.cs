using DonationAPI.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DonationAPI.Controllers.Interfaces
{
    public interface IDonationController
    {
        public Task<IActionResult> StoreDonation([FromBody] DonationDTO donationDTO);
        public Task<IActionResult> GetDonationByKey(string partitionKey, string rowKey);
        public Task<IActionResult> GetAllDonations();
        public Task<IActionResult> DeleteDonation(string partitionKey, string rowKey);
    }
}
