using PublishDonationMessageOntoQueue.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace PublishDonationMessageOntoQueue.Controllers.Interfaces
{
    public interface IDonationController
    {
        public IActionResult StoreDonation([FromBody] DonationDTO donationDTO);
        public IActionResult GetDonationById(int id);
        public IActionResult GetAllDonations();
        public IActionResult DeleteDonation(int id);
    }
}
