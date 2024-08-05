using VoteSystems.InstantRunoff;

namespace VoteSystems
{

    public static class Program
    {
        public static void Main(string[] args ) 
        {
            InstantRunoffVoteArray votes = new InstantRunoffVoteArray();
            SeedArray seed = new SeedArray();
            seed.Seed(votes, 100);
            //votes.PrintVotes();
            InstantRunoffSystem.DefineWinner(votes);
        }
    }
}