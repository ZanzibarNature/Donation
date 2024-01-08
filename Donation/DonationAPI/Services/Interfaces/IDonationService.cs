using DonationAPI.Domain;
using DonationAPI.Domain.DTO;

namespace DonationAPI.Services.Interfaces
{
    public interface IDonationService
    {
        public Donation StoreDonation(Donation donation);
        public Donation GetDonationById(int id);
        public List<Donation> GetAllDonations();
        public Donation UpdateDonation(int id, DonationDTO donationDTO);
        public int DeleteDonation(int id);
    }
}
