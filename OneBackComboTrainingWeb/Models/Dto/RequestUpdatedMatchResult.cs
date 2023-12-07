using OneBackComboTrainingWeb.Models.Enum;

namespace OneBackComboTrainingWeb.Models.Dto;

public class RequestUpdatedMatchResult
{
    public int MatchId { get; set; }
    public EventCodeEnum EventCode { get; set; }
}