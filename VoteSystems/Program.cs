using VoteSystems.InstantRunoff;

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
            instantRunoffSystem.DefineWinner(votes);
        }
    }
}