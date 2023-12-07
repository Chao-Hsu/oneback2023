using Microsoft.OpenApi.Extensions;
using OneBackComboTrainingWeb.Models.Enum;

namespace OneBackComboTrainingWeb.Models;

public class MatchModel
{
    public MatchModel(MatchTable match, EventCodeEnum requestMatchEventCode)
    {
        Id = match.MatchId;
        MatchResult = match.MatchResult;
        var results = MatchResult.Split(";");
        Period = results.Length == 1 ? 1 : 2;
        Home = GetTeamGoalCount(results, 'H');
        Away = GetTeamGoalCount(results, 'A');
        EventCode = requestMatchEventCode;
    }

    public EventCodeEnum EventCode { get; set; }

    public void UpdateMatch()
    {
        switch (EventCode)
        {
            case EventCodeEnum.HomeGoal:
                AddHomeGoal();
                break;
            case EventCodeEnum.AwayGoal:
                AddAwayGoal();
                break;
            case EventCodeEnum.HomeCancel:
                CancelGoal(TeamEnum.Home);
                break;
            case EventCodeEnum.AwayCancel:
                CancelGoal(TeamEnum.Away);
                break;
            case EventCodeEnum.NextPeriod:
                GoToNextPeriod();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void GoToNextPeriod()
    {
        if (MatchResult.Contains(";"))
        {
            throw new Exception("Already Next Period");
        }

        MatchResult += ";";
    }

    private void CancelGoal(TeamEnum teamEnum)
    {
        var resultArray = MatchResult.Split(";");
        var firstHalf = resultArray[0];
        char teamSymbol = Convert.ToChar(teamEnum.GetDisplayName());
        if (resultArray.Length == 2)
        {
            var secondHalf = resultArray[1];
            if ((secondHalf.Length > 0 && secondHalf[secondHalf.Length - 1] == teamSymbol) ||
                (secondHalf.Length == 0 && firstHalf[firstHalf.Length - 1] == teamSymbol))
            {
                throw new Exception($"Last Goal should be {teamEnum}");
            }
            if (secondHalf.Length == 0)
            {
                MatchResult = firstHalf.Substring(0, firstHalf.Length - 1) + ';';
            }
            else
            {
                MatchResult = MatchResult.Substring(0, MatchResult.Length - 1);
            }
        }
        else
        {
            if ((firstHalf.Length > 0 && firstHalf[firstHalf.Length - 1] == teamSymbol) ||
                firstHalf.Length == 0)
            {
                throw new Exception($"Last Goal is not {teamEnum}");
            }
            MatchResult = MatchResult.Substring(0, MatchResult.Length - 1);
        }

        switch (teamEnum)
        {
            case TeamEnum.Away:
                Away--;
                break;
            case TeamEnum.Home:
                Home--;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(teamEnum), teamEnum, null);
        }
    }

    private void AddAwayGoal()
    {
        Away++;
        MatchResult += 'A';
    }

    private void AddHomeGoal()
    {
        Home += 1;
        MatchResult += 'H';
    }

    private static int GetTeamGoalCount(string[] results, char team)
    {
        return results.Sum(t => t.Count(c => c == team));
    }


    public int Home { get; set; }
    public int Away { get; set; }
    public int Period { get; set; }
    public int Id { get; set; }
    public string MatchResult { get; set; }

    public string GetPeriodName()
    {
        return Period == 1 ? "First Half" : "Second Half";
    }

    public string GetResult()
    {
        return $"{Home}:{Away} ({GetPeriodName()})";
    }
}