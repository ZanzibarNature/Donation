using Azure;
using Azure.Data.Tables;

namespace PublishDonationMessageOntoQueue.DAL.Repos.Interfaces
{
    internal interface IDonationRepository<T> where T : class, ITableEntity, new()
    {
        Task<T> GetDonationByIdAsync(string partitionKey, string rowKey);
        Task<IEnumerable<T>> GetAllDonationsAsync();
        Task<Response> UpsertDonationAsync(T donation);
        Task<Response> DeleteDonationAsync(string partitionKey, string rowKey);
    }
}
