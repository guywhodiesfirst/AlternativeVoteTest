namespace VoteSystems
{

    public static class Program
    {
        public static void Main(string[] args ) 
        {
            VoteArray votes = new VoteArray();
            SeedArray seed = new SeedArray();
            seed.Seed(votes, 70);
            //votes.PrintVotes();
            AlternativeVote.DefineWinner(votes);
        }
    }
}