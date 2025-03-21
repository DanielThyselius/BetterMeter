namespace BetterMeter.Api.Endpoints;
public class GetQuestion : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) =>  app
        .MapGet("/api/questions/{id}", Handle)
        .RequireAuthorization()
        .WithSummary("Get question");

    // Request and Response types
    public record Request(int Id);

    public record Response(
        int Id,
        string Title,
        string Answer,
        int Points,
        int Time,
        bool IsOpenEnded,
        List<string>? Alternatives
    );


    //Logic
    private static Response Handle([AsParameters] Request request, IDatabase db)
    {
        var item = db.Questions.Find(q => q.Id == request.Id);

        // map ev to response dto
        var response = new Response(
                Id: item.Id,
                Title: item.Title,
                Answer: item.Answer,
                Points: item.Points,
                Time: item.SecondsToAnswer,
                IsOpenEnded: item.IsOpenEnded,
                Alternatives: item.Alternatives 
            );

        return response;
    }
}