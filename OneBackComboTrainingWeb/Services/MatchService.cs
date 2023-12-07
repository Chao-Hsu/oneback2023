using OneBackComboTrainingWeb.Models;
using OneBackComboTrainingWeb.Models.Dto;
using OneBackComboTrainingWeb.Repos;

namespace OneBackComboTrainingWeb.Services;

public class MatchService
{
    private IMatchRepo _repo;

    public MatchService(IMatchRepo repo)
    {
        _repo = repo;
    }

    public MatchDto UpdateMatchResult(RequestUpdatedMatchResult request)
    {
        var match = _repo.GetMatch(request.MatchId);

        var matchModel = new MatchModel(match, request.EventCode);
        matchModel.UpdateMatch();
        _repo.UpdateDbMatch();
        //todo log

        return new MatchDto(matchModel);
    }
}