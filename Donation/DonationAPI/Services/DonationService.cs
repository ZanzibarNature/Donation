using DonationAPI.DAL.Repos.Interfaces;
using DonationAPI.Domain;
using DonationAPI.Domain.DTO;
using DonationAPI.Services.Interfaces;

namespace DonationAPI.Services
{
    public class DonationService : IDonationService
    {
        private readonly IDonationRepository<Donation> _donationRepository;

        public DonationService(IDonationRepository<Donation> donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public int DeleteDonation(int id)
        {
            throw new NotImplementedException();
        }

        public List<Donation> GetAllDonations()
        {
            throw new NotImplementedException();
        }

        public Donation GetDonationById(int id)
        {
            throw new NotImplementedException();
        }

        public Donation StoreDonation(Donation donation)
        {
            throw new NotImplementedException();
        }

        public Donation UpdateDonation(int id, DonationDTO donationDTO)
        {
            throw new NotImplementedException();
        }
    }
}