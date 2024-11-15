using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace XoperoRekrutacja.Logic.Services.Issue
{
    public class GitHubIssueService : IIssueService
    {
        private readonly HttpClient _httpClient;
        private readonly string _repoOwner;
        private readonly string _repoName;

        public GitHubIssueService(HttpClient httpClient, string repoOwner, string repoName)
        {
            _httpClient = httpClient;
            _repoOwner = repoOwner;
            _repoName = repoName;
        }

        public async Task<bool> CloseIssueAsync(int issueId)
        {

            var payload = new { state = "closed" };

            var response = await _httpClient.PatchAsync(
                $"https://api.github.com/repos/{_repoOwner}/{_repoName}/issues/{issueId}",
                new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CreateIssueAsync(string name, string description)
        {
            var payload = new
            {
                title = name,
                body = description
            };

            var response = await _httpClient.PostAsJsonAsync(
                $"https://api.github.com/repos/{_repoOwner}/{_repoName}/issues",
                payload);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateIssueAsync(int issueId, string name, string description)
        {
            var payload = new
            {
                title = name,
                body = description
            };

            var response = await _httpClient.PatchAsync(
                $"https://api.github.com/repos/{_repoOwner}/{_repoName}/issues/{issueId}",
                new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }
    }
}