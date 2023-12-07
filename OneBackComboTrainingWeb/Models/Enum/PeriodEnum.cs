using System.ComponentModel;
using System.Reflection;

namespace OneBackComboTrainingWeb.Models.Enum;

public enum PeriodEnum
{
    [Description("First Half")]
    FirstHalf = 1,
    [Description("Second Half")]
    SecondHalf = 2,
}