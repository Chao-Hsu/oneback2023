using FluentAssertions;
using NSubstitute;
using OneBackComboTrainingWeb.Models;
using OneBackComboTrainingWeb.Models.Dto;
using OneBackComboTrainingWeb.Models.Enum;
using OneBackComboTrainingWeb.Services;
using OneBackComboTrainingWeb.Repos;

namespace OneBackTests;

public class MatchServiceTests
{
    private IMatchRepo _matchRepo;
    private MatchService _matchService;

    public MatchServiceTests()
    {
    }

    [SetUp]
    public void SetUp()
    {
        _matchRepo = Substitute.For<IMatchRepo>();
        _matchService = new MatchService(_matchRepo);
    }

    [Test]
    public void home_goal()
    {
        GivenMatchTable(99999999, string.Empty);
        var updateMatchResult = WhenHomeGoal(99999999);
        MatchResultShouldBe(updateMatchResult, "1:0 (First Half)");
    }

    private static void MatchResultShouldBe(MatchDto updateMatchResult, string expected)
    {
        updateMatchResult.Result.Should().Be(expected);
    }

    private MatchDto WhenHomeGoal(int matchId)
    {
        var updatedMatchDto = new RequestUpdatedMatchResult { MatchId = matchId, EventCode = EventCodeEnum.HomeGoal };
        return _matchService.UpdateMatchResult(updatedMatchDto);
    }

    private void GivenMatchTable(int matchId, string matchResult)
    {
        _matchRepo.GetMatch(Arg.Any<int>()).Returns(new MatchTable() { MatchId = matchId, MatchResult = matchResult });
    }
}