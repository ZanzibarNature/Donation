using DonationAPI.DAL.Repos;
using DonationAPI.DAL.Repos.Interfaces;
using DonationAPI.Domain;
using DonationAPI.Domain.DTO;
using DonationAPI.Services;
using DonationAPI.Services.Interfaces;
using Moq;

namespace DonationAPI.Tests
{
    public class DonationServiceTest
    {
        private readonly Mock<IDonationRepository<Donation>> _mockDonationRepo;
        private readonly IDonationService _donationService;
        private readonly string _mockRowKey;
        private readonly string _mockPartKey;
        private DonationDTO _mockDonationDTO;
        private Donation _mockDonation;

        public DonationServiceTest() 
        {
            _mockDonationRepo = new Mock<IDonationRepository<Donation>>();
            _mockRowKey = Guid.NewGuid().ToString();
            _mockPartKey = "Donation";
            _donationService = new DonationService(_mockDonationRepo.Object);
            _mockDonationDTO = new DonationDTO
            {
                UserId = 9999999,
                Amount = 9999999.99,
                ArticleId = 1
            };
            _mockDonation = new Donation
            {
                UserId = 9999999,
                Amount = 9999999.99,
                ArticleId = 1,
                PartitionKey = _mockPartKey,
                RowKey = _mockRowKey,
                ETag = new Azure.ETag(),
                Timestamp = DateTime.UtcNow
            };
        }
        
        [Fact]
        public async Task CreateDonationAsync_ShouldCreateDonationAsyncAndReturnDonation()
        {
            var result = await _donationService.CreateDonationAsync(_mockDonationDTO);
            Assert.NotNull(result);
            Assert.IsType<Donation>(result);
            Assert.Equal(_mockDonationDTO.Amount, result.Amount);
            Assert.Equal(_mockDonationDTO.UserId, result.UserId);
            Assert.Equal(_mockDonationDTO.ArticleId, result.ArticleId);
            _mockDonationRepo.Verify(repo => repo.UpsertDonationAsync(It.IsAny<Donation>()), Times.Once);
        }

        [Fact]
        public async Task GetDonationByKeyAsync_ShouldGetDonationByKeyAsyncAndReturnDonation()
        {
            _mockDonationRepo.Setup(repo => repo.GetDonationByIdAsync(_mockPartKey, _mockRowKey))
                .ReturnsAsync(_mockDonation);
            
            var result = await _donationService.GetDonationByKeyAsync(_mockDonation.PartitionKey, _mockDonation.RowKey);
            Assert.NotNull(result);
            Assert.IsType<Donation>(result);
            Assert.Equal(_mockDonation, result);
            _mockDonationRepo.Verify(repo => repo.GetDonationByIdAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task GetPagesOfDonationsAsync_ShouldGetPagesOfDonationsAsync()
        {
            var mockDonation1 = await _donationService.CreateDonationAsync(_mockDonationDTO);
            Assert.NotNull(mockDonation1);
            var mockDonation2 = await _donationService.CreateDonationAsync(_mockDonationDTO);
            Assert.NotNull(mockDonation2);
            var mockDonation3 = await _donationService.CreateDonationAsync(_mockDonationDTO);
            Assert.NotNull(mockDonation3);

            var mockDonations = await _donationService.GetPagesOfDonationsAsync();
            _mockDonationRepo.Verify(repo => repo.GetPagesOfDonationsAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateDonationAsync_ShouldUpdateDonationAsync()
        {
            var updateDonationDTO = new UpdateDonationDTO
            {
                PartitionKey = _mockPartKey,
                RowKey = _mockRowKey.ToString(),
                Amount = 123.45, // New amount for update
                ArticleId = 2 // New article ID for update
            };

            var result = await _donationService.UpdateDonationAsync(updateDonationDTO);

            Assert.NotNull(result);
            Assert.Equal(updateDonationDTO.Amount, result.Amount);
            Assert.Equal(updateDonationDTO.ArticleId, result.ArticleId);
            Assert.Equal(_mockRowKey.ToString(), result.RowKey); // Ensure RowKey remains the same
            Assert.Equal(_mockPartKey, result.PartitionKey); // Ensure PartitionKey remains the same
            _mockDonationRepo.Verify(repo => repo.UpsertDonationAsync(It.IsAny<Donation>()), Times.Once);
        }

        [Fact]
        public async Task DeleteDonationAsync_ShouldDeleteDonationAsync()
        {
            // Would be cool if we had an actual object to delete
            var mockDonation = await _donationService.CreateDonationAsync(_mockDonationDTO);
            Assert.NotNull(mockDonation);

            var result = await _donationService.DeleteDonationAsync(mockDonation.PartitionKey, mockDonation.RowKey);

            Assert.Null(result);
            _mockDonationRepo.Verify(repo => repo.DeleteDonationAsync(mockDonation.PartitionKey, mockDonation.RowKey), Times.Once);
        }
    }
}