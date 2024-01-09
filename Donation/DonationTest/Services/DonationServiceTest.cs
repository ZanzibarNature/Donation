using DonationAPI.DAL.Repos;
using DonationAPI.Domain;
using DonationAPI.Services;
using DonationAPI.Services.Interfaces;
using Moq;

namespace DonationTest.Services
{
    public class DonationServiceTest
    {
        private readonly Mock<DonationRepository<Donation>> _mockDonation;
        private readonly IDonationService _mockDonationService;
        private readonly Guid _mockRowKey;
        private readonly string _mockPartKey;

        public DonationServiceTest() 
        {
            _mockDonation = new Mock<DonationRepository<Donation>>();
            _mockRowKey = Guid.NewGuid();
            _mockPartKey = "Donation";
            _mockDonationService = new DonationService(_mockDonation.Object);
        }
        
        [Fact]
        public void Test1()
        {

        }
    }
}