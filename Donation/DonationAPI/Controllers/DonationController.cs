using DonationAPI.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using DonationAPI.Controllers.Interfaces;
using DonationAPI.Services.Interfaces;
using DonationAPI.Services;

namespace DonationAPI.Controllers
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
