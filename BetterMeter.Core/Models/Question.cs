namespace BetterMeter.Core.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; } = "Question";
        public string  Answer { get; set; } = "42";
        public int Points { get; set; }
        public int SecondsToAnswer { get; set; } = 30;
        public bool IsOpenEnded { get; set; }
        public List<string>? Alternatives { get; set; }
    }
}
