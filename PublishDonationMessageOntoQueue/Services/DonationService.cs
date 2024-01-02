using PublishDonationMessageOntoQueue.Domain;
using PublishDonationMessageOntoQueue.Domain.DTO;
using PublishDonationMessageOntoQueue.Services.Interfaces;

namespace PublishDonationMessageOntoQueue.Services
{
    public class DonationService : IDonationService
    {
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