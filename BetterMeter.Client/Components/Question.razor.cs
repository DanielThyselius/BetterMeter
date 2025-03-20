using Microsoft.AspNetCore.Components;
namespace BetterMeter.Client.Components;

public partial class Question
{
    [Parameter]
    public string Title { get; set; } = "What is your name?";

    [Parameter]
    public int Points { get; set; }

    [Parameter]
    public List<string> Alternatives { get; set; }
}