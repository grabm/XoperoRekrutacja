namespace XoperoRekrutacja.Logic.Services.Issue
{
    public  interface IIssueService
    {
        Task<bool> CreateIssueAsync(string name, string description);
        Task<bool> UpdateIssueAsync(int issueId, string name, string description);
        Task<bool> CloseIssueAsync(int issueId);
    }
}