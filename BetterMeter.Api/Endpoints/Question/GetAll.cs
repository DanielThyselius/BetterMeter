namespace BetterMeter.Api.Endpoints;
public class GetAllEvents : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/api/questions", Handle)
        .WithSummary("Get all questions");

    // Request and Response types
    public record Response(
        int Id,
        string Title,
        string Answer,
        int Points,
        int Time,
        bool IsOpenEnded
    );

    //Logic
    private static List<Response> Handle(IDatabase db)
    {
        return db.Questions
            .Select(item => new Response(
                Id: item.Id,
                Title: item.Title,
                Answer: item.Answer,
                Points: item.Points,
                Time: item.SecondsToAnswer,
                IsOpenEnded: item.IsOpenEnded
            )).ToList();
    }
}