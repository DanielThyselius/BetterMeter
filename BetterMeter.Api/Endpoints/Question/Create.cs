using BetterMeter.Core.Models;

namespace BetterMeter.Api.Endpoints;
public class CreateQuestion : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/api/questions", Handle)
        .WithSummary("Create question");

    // Request and Response types
    // Why do we need these? check this video if you are not sure
    // https://youtu.be/xtpPspNdX58?si=GJBUxMzeR2ZJ5Fg_
    public record Request(
       string Title,
       string Answer,
       int Points,
       int Time,
       bool IsOpenEnded,
       List<string>? Alternatives
        );
    public record Response(int id);

    //Logic
    private static Ok<Response> Handle(Request request, IDatabase db)
    {
        // Todo, use a better constructor that enforces setting all necessary properties
        var q = new Question();

        // Map request to an event-object
        q.Title = request.Title;
        q.Answer = request.Answer;
        q.Points = request.Points;
        q.SecondsToAnswer = request.Time;
        q.IsOpenEnded = request.IsOpenEnded;
        q.Alternatives = request.Alternatives;


        // Todo: handle in service?
        db.Questions.Add(q); 

        return TypedResults.Ok(new Response(q.Id));
    }
}

