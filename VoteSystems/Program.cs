using VoteSystems.InstantRunoff;
using VoteSystems.Results;

namespace VoteSystems
{

    public static class Program
    {
        public static void Main() 
        {
            InstantRunoffVoteArray votes = new();
            SeedArray seed = new();
            seed.Seed(votes, 100);
            InstantRunoffSystem instantRunoffSystem = new();
            ConstituencyResult result = instantRunoffSystem.DefineWinnerInConstituency(votes);
            Console.WriteLine($"Winner: {result.Winner}");
            foreach(string logEntry in result.Log)
            {
                Console.WriteLine(logEntry);
            }
        }
    }
}