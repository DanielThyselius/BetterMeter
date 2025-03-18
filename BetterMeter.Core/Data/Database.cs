using BetterMeter.Core.Models;

namespace BetterMeter.Core.Data;

public interface IDatabase
{
    List<Question> Questions { get; set; }
}

public class Database : IDatabase
{
    public List<Question> Questions { get; set; } = new List<Question>();
}