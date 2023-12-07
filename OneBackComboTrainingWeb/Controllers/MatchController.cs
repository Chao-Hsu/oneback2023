using Microsoft.AspNetCore.Mvc;
using OneBackComboTrainingWeb.Models.Dto;
using OneBackComboTrainingWeb.Repos;
using OneBackComboTrainingWeb.Services;

namespace OneBackComboTrainingWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class MatchController : ControllerBase
{
    [HttpGet(Name = "UpdateMatchResult")]
    public string UpdateMatchResult(RequestUpdatedMatchResult request)
    {
        var matchService = new MatchService(new MatchRepo());
        var responseMatch = matchService.UpdateMatchResult(request);
        return responseMatch.Result;
    }
}