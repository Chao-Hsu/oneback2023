using Microsoft.OpenApi.Extensions;
using OneBackComboTrainingWeb.Models.Enum;

namespace OneBackComboTrainingWeb.Models.Dto;

public class MatchDto
{
    public MatchDto(MatchModel matchModel)
    {
        Result = matchModel.GetResult();
    }

    public string Result { get; set; }
}