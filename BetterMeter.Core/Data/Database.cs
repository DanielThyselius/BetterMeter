using BetterMeter.Core.Models;

namespace BetterMeter.Core.Data;

public interface IDatabase
{
    List<Question> Questions { get; set; }
}

public class Database : IDatabase
{
    public List<Question> Questions { get; set; } = GetDemoData();

    private static List<Question> GetDemoData()
    {
        return new List<Question>()
        {
            new()
            {
                Id = 1,
                Title = "What is the capital of France?",
                Answer = "Paris",
                Points = 10,
                SecondsToAnswer = 10,
                Alternatives = new List<string>() { "London", "Berlin", "Paris", "Madrid" }
            },
            new ()
            {
                Id = 2,
                Title = "What is the capital of Germany?",
                Answer = "Berlin",
                Points = 10,
                SecondsToAnswer = 10,
                Alternatives = new List<string>() { "London", "Berlin", "Paris", "Madrid" }
            },
            new Question()
            {
                Id = 3,
                Title = "What is the capital of Spain?",
                Answer = "Madrid",
                Points = 10,
                SecondsToAnswer = 10,
                Alternatives = new List<string>() { "London", "Berlin", "Paris", "Madrid" }
            },
            new Question()
            {
                Id = 4,
                Title = "What is the capital of the United Kingdom?",
                Answer = "London",
                Points = 10,
                SecondsToAnswer = 10,
                Alternatives = new List<string>() { "London", "Berlin", "Paris", "Madrid" }
            },
            new Question()
            {
                Id = 5,
                Title = "What is the capital of Italy?",
                Answer = "Rome",
                Points = 10,
                SecondsToAnswer = 10,
                Alternatives = new List<string>() { "London", "Berlin", "Paris", "Madrid" }
            },
            new Question()
            {
                Id = 6,
                Title = "What is the capital of the United States?",
                Answer = "Washington D.C.",
                Points = 10,
                SecondsToAnswer = 10,
                Alternatives = new List<string>() { "New York", "Los Angeles", "Washington D.C.", "Chicago" }
            },
            new Question()
            {
                Id = 7,
                Title = "What is the capital of Canada?",
                Answer = "Ottawa",
                Points = 10,
                SecondsToAnswer = 10,
                Alternatives = new List<string>() { "Toronto", "Vancouver", "Ottawa", "Montreal" }
            },
            new Question()
            {
                Id = 8,
                Title = "What is the capital of Australia?",
                Answer = "Canberra",
                Points = 10,
                SecondsToAnswer = 10,
                Alternatives = new List<string>() { "Sydney", "Melbourne", "Canberra", "Brisbane" }
            },
        };
    }
}