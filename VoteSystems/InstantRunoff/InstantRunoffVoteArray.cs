using VoteSystems.BaseClasses;

namespace VoteSystems.InstantRunoff
{
    public class InstantRunoffVoteArray : BaseVoteArray<InstantRunoffVote>
    {
        public int VoteCount => Votes.Count;
        public int CandidateCount => Votes[0].CandidateCount;

        public InstantRunoffVoteArray() : base() { }
        public InstantRunoffVoteArray(InstantRunoffVoteArray other) : base(other) {}
        public void EliminateCandidate(string candidateName)
        {
            if (string.IsNullOrEmpty(candidateName))
            {
                throw new ArgumentNullException(nameof(candidateName), "Candidate name cannot be null or empty.");
            }

            foreach (var vote in Votes)
            {
                vote.EliminateCandidate(candidateName);
            }
            SetFirstPreferences();
        }

        protected override void SetFirstPreferences()
        {
            FirstPreferences.Clear();
            if(VoteCount > 0) 
            {
                var firstVote = Votes.First();
                var candidates = firstVote.Bulletin.Select(c => c.Key).Distinct();

                foreach (var candidate in candidates)
                {
                    FirstPreferences[candidate] = Votes.Count(vote => vote.Bulletin[candidate] == 1);
                }
            }
        }

        public bool HasWinner()
        {
            int votesToWin = VoteCount / 2 + 1;

            return CandidateCount == 1 || FirstPreferences.Any(pair => pair.Value >= votesToWin);
        }
    }
}