using Microsoft.AspNetCore.Mvc;
using OneBackComboTrainingWeb.Models.Dto;
using OneBackComboTrainingWeb.Repos;
using OneBackComboTrainingWeb.Services;

namespace OneBackComboTrainingWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class MatchController : ControllerBase
{

    private MatchService _matchService;

    public MatchController(MatchService matchService)
    {
        _matchService = matchService;
    }

    [HttpGet(Name = "UpdateMatchResult")]
    public string UpdateMatchResult(RequestUpdatedMatchResult request)
    {
        var responseMatch = _matchService.UpdateMatchResult(request);
        return responseMatch.Result;
    }
}