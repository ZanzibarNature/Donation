using Azure;
using DonationAPI.Controllers.Interfaces;
using DonationAPI.Domain;
using DonationAPI.Domain.DTO;
using DonationAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DonationAPI.Controllers
{
    [ApiController]
    [Route("api/Donation/")]
    public class DonationController : Controller, IDonationController
    {
        private readonly IDonationService _service;
        public DonationController(IDonationService service)
        {
            _service = service;
        }

        [HttpDelete("Delete/{partitionKey}/{rowKey}")]
        public async Task<IActionResult> DeleteDonation(string partitionKey, string rowKey)
        {
            Response r = await _service.DeleteDonationAsync(partitionKey, rowKey);

            return r.IsError ? NotFound("Given key pair not found!") : Ok("Deleting donation succesful!");
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllDonations()
        {
            IList<Donation> donations = await _service.GetAllDonationsAsync();

            return donations.Count == 0 ? NotFound("Nothing found!") : Ok(donations);
        }

        [HttpGet("GetByKey/{partitionKey}/{rowKey}")]
        public async Task<IActionResult> GetDonationByKey(string partitionKey, string rowKey)
        {
            Donation donation = await _service.GetDonationByKeyAsync(partitionKey, rowKey);

            return donation == null ? NotFound($"No donation found for {rowKey}!") : Ok(donation);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> StoreDonation([FromBody] DonationDTO donationDTO)
        {
            if (donationDTO == null)
            {
                return BadRequest("Request data is empty or invalid!");
            }

            Donation donation = await _service.UpdateDonationAsync(donationDTO);

            return CreatedAtAction(nameof(GetDonationByKey), new { partitionKey = donation.PartitionKey, rowKey = donation.RowKey }, donation);
        }
    }
}
