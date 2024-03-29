﻿using Azure;
using DonationAPI.Controllers.Interfaces;
using DonationAPI.Domain;
using DonationAPI.Domain.DTO;
using DonationAPI.Middleware;
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

        [Auth]
        [HttpDelete("Delete/{partitionKey}/{rowKey}")]
        public async Task<IActionResult> DeleteDonation(string partitionKey, string rowKey)
        {
            Response r = await _service.DeleteDonationAsync(partitionKey, rowKey);

            return r.IsError ? NotFound("Given key pair not found!") : Ok("Deleting donation succesful!");
        }

        [Auth]
        [HttpGet("GetPages")]
        public async Task<IActionResult> GetPagesOfDonationsAsync()
        {
            IList<Donation> donations = await _service.GetPagesOfDonationsAsync();

            return donations.Count == 0 ? NotFound("Nothing found!") : Ok(donations);
        }

        [Auth]
        [HttpGet("GetByKey/{partitionKey}/{rowKey}")]
        public async Task<IActionResult> GetDonationByKey(string partitionKey, string rowKey)
        {
            Donation donation = await _service.GetDonationByKeyAsync(partitionKey, rowKey);

            return donation == null ? NotFound($"No donation found for {rowKey}!") : Ok(donation);
        }

        [Auth]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateDonation([FromBody] UpdateDonationDTO donationDTO)
        {
            if (donationDTO == null)
            {
                return BadRequest("Request data is empty or invalid!");
            }

            Donation donation = await _service.UpdateDonationAsync(donationDTO);

            return Ok(donation);
        }

        [Auth]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateDonation([FromBody] DonationDTO donationDTO)
        {
            if (donationDTO == null)
            {
                return BadRequest("Request data is empty or invalid!");
            }

            Donation donation = await _service.CreateDonationAsync(donationDTO);

            return CreatedAtAction(nameof(GetDonationByKey), new { partitionKey = donation.PartitionKey, rowKey = donation.RowKey }, donation);
        }
    }
}
