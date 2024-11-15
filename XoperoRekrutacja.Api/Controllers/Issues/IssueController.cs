using Microsoft.AspNetCore.Mvc;
using XoperoRekrutacja.Api.Models.Requests;
using XoperoRekrutacja.Logic.Services.Issue;

namespace XoperoRekrutacja.Api.Controllers.Issues
{
    [ApiController]
    [Route("api/issues")]
    public class IssueController : Controller
    {
        private readonly IIssueService _issueService;
        public IssueController(IIssueService issueService)
        {
            _issueService = issueService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateIssue([FromBody] IssueRequest request)
        {
            bool success = await _issueService.CreateIssueAsync(request.Name, request.Description);
            return success ? Ok() : StatusCode(500);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIssue(int id, [FromBody] IssueRequest request)
        {
            bool success = await _issueService.UpdateIssueAsync(id, request.Name, request.Description);
            return success ? Ok() : StatusCode(500);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CloseIssue(int id)
        {
            bool success = await _issueService.CloseIssueAsync(id);
            return success ? Ok() : StatusCode(500);
        }
    }
}