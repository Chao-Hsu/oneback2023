using OneBackComboTrainingWeb.Models;

namespace OneBackComboTrainingWeb.Repos;

public interface IMatchRepo
{
    MatchTable GetMatch(int id);
    void UpdateDbMatch();
}