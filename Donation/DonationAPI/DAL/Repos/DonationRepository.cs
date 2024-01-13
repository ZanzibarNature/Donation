using Azure;
using Azure.Data.Tables;
using DonationAPI.DAL.Repos.Interfaces;

namespace DonationAPI.DAL.Repos
{
    public class DonationRepository<T> : IDonationRepository<T> where T : class, ITableEntity, new()
    {
        private readonly TableClient _client;

        public DonationRepository(IConfiguration config)
        {
            IConfiguration _config = config;
            TableServiceClient tableServiceClient = new TableServiceClient(Environment.GetEnvironmentVariable("AZURE_CONNECTION") ?? _config["AppStorage"]);
            tableServiceClient.CreateTableIfNotExists("donations");
            _client = tableServiceClient.GetTableClient("donations");
        }

        public async Task<Response> DeleteDonationAsync(string partitionKey, string rowKey)
        {
            return await _client.DeleteEntityAsync(partitionKey, rowKey);
        }

        public async Task<IList<T>> GetAllDonationsAsync()
        {
            IList<T> results = new List<T>();
            var donations = _client.QueryAsync<T>(maxPerPage: 25);
            await foreach (var donation in donations)
            {
                results.Add(donation);
            }

            return results;
        }

        public async Task<T> GetDonationByIdAsync(string partitionKey, string rowKey)
        {
            return await _client.GetEntityAsync<T>(partitionKey, rowKey);
        }

        public async Task<Response> UpsertDonationAsync(T donation)
        {
            return await _client.UpsertEntityAsync(donation);
        }
    }
}
