using Azure;
using Azure.Data.Tables;

namespace DonationAPI.DAL.Repos.Interfaces
{
    public interface IDonationRepository<T> where T : class, ITableEntity, new()
    {
        Task<T> GetDonationByIdAsync(string partitionKey, string rowKey);
        Task<IList<T>> GetAllDonationsAsync();
        Task<Response> UpsertDonationAsync(T donation);
        Task<Response> DeleteDonationAsync(string partitionKey, string rowKey);
    }
}
