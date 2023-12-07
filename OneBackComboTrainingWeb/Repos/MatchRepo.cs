using OneBackComboTrainingWeb.Models;

namespace OneBackComboTrainingWeb.Repos;

public class MatchRepo : IMatchRepo
{
    public MatchTable GetMatch(int id)
    {
        return new MatchTable();
    }

    public void UpdateDbMatch()
    {
    }
}