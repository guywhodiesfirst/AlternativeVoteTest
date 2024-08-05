namespace VoteSystems.InstantRunoff
{
    public static class InstantRunoffSystem
    {
        public static string DefineWinner(InstantRunoffVoteArray votes)
        {
            InstantRunoffVoteArray workingVotes = new InstantRunoffVoteArray(votes);
            while (!workingVotes.HasWinner())
            {
                workingVotes.PrintFirstPreferences();
                string candidateToEliminate = workingVotes.GetLeastPopularCandidate();
                Console.WriteLine($"Candidate to eliminate: {candidateToEliminate}");
                workingVotes.EliminateCandidate(candidateToEliminate);
                Console.WriteLine();
            }

            workingVotes.PrintFirstPreferences();
            Console.WriteLine($"Winner: {workingVotes.GetMostPopularCandidate()}");
            return workingVotes.GetMostPopularCandidate();
        }
    }
}
