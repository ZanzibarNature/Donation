using PublishDonationMessageOntoQueue.Domain;
using PublishDonationMessageOntoQueue.Domain.DTO;

namespace PublishDonationMessageOntoQueue.Services.Interfaces
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
