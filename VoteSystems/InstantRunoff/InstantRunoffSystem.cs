namespace VoteSystems.InstantRunoff
{
    public static class InstantRunoffSystem
    {
        public static string DefineWinner(InstantRunoffVoteArray votes)
        {
            InstantRunoffVoteArray workingVotes = new InstantRunoffVoteArray(votes);
            while (!workingVotes.HasWinner())
            {
                Console.WriteLine(workingVotes.FirstPreferencesToString());
                string candidateToEliminate = workingVotes.GetLeastPopularCandidate();
                Console.WriteLine($"Candidate to eliminate: {candidateToEliminate}");
                workingVotes.EliminateCandidate(candidateToEliminate);
                Console.WriteLine();
            }

            Console.WriteLine(workingVotes.FirstPreferencesToString());
            Console.WriteLine($"Winner: {workingVotes.GetMostPopularCandidate()}");
            return workingVotes.GetMostPopularCandidate();
        }
    }
}
