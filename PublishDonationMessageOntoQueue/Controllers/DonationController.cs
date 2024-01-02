using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using PublishDonationMessageOntoQueue.Controllers.Interfaces;
using Service.Interfaces;

namespace PublishDonationMessageOntoQueue.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DonationController : Controller, IDonationController
    {
        private readonly IDonationService _service;
        public DonationController(DonationService service)
        {
            _service = service;
        }

        public IActionResult DeleteDonation(int id)
        {
            throw new NotImplementedException();
        }

        public IActionResult GetAllDonations()
        {
            throw new NotImplementedException();
        }

        public IActionResult GetDonationById(int id)
        {
            throw new NotImplementedException();
        }

        public IActionResult StoreDonation([FromBody] DonationDTO donationDTO)
        {
            throw new NotImplementedException();
        }
    }
}
