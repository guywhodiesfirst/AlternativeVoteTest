using VoteSystems.BaseClasses;

namespace VoteSystems.InstantRunoff
{
    public class InstantRunoffSystem : BaseVotingSystem<InstantRunoffVoteArray>
    {
        public override string DefineWinner(InstantRunoffVoteArray votes)
        {
            InstantRunoffVoteArray workingVotes = new(votes);
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
