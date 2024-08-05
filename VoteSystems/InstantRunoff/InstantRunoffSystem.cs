using VoteSystems.BaseClasses;
using VoteSystems.Results;

namespace VoteSystems.InstantRunoff
{
    public class InstantRunoffSystem : BaseVotingSystem<InstantRunoffVoteArray>
    {
        public override ConstituencyResult DefineWinnerInConstituency(InstantRunoffVoteArray votes)
        {
            InstantRunoffVoteArray workingVotes = new(votes);
            List<string> log = new();
            while (!workingVotes.HasWinner())
            {
                string logEntry = workingVotes.FirstPreferencesToString();
                string candidateToEliminate = workingVotes.GetLeastPopularCandidate();
                logEntry += $"Candidate eliminated: {candidateToEliminate}\n";
                log.Add(logEntry);
                workingVotes.EliminateCandidate(candidateToEliminate);
            }

            log.Add(workingVotes.FirstPreferencesToString());
            return new ConstituencyResult(log, workingVotes.GetMostPopularCandidate());
        }
    }
}
