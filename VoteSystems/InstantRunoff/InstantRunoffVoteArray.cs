using VoteSystems.Interfaces;

namespace VoteSystems.InstantRunoff
{
    public class InstantRunoffVoteArray : IVoteArray<List<InstantRunoffVote>, InstantRunoffVote>
    {
        public List<InstantRunoffVote> Votes { get; set; }
        private Dictionary<string, int> _firstPreferences;
        public int VoteCount => Votes.Count;
        public int CandidateCount => Votes[0].CandidateCount;

        public InstantRunoffVoteArray()
        {
            Votes = new List<InstantRunoffVote>();
            _firstPreferences = new Dictionary<string, int>();
            SetFirstPreferences();
        }
        public InstantRunoffVoteArray(InstantRunoffVoteArray another)
        {
            Votes = new List<InstantRunoffVote>(another.Votes);
            _firstPreferences = new Dictionary<string, int>(another._firstPreferences);
        }
        public void Add(InstantRunoffVote vote)
        {
            Votes.Add(vote);
            SetFirstPreferences();
        }

        public void PrintFirstPreferences()
        {
            foreach (var candidate in _firstPreferences)
            {
                Console.WriteLine($"{candidate.Key}: {candidate.Value}");
            }
        }

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

        private void SetFirstPreferences()
        {
            _firstPreferences.Clear();
            if(VoteCount > 0) 
            {
                var voteExample = Votes.FirstOrDefault();
                if (voteExample != null)
                {
                    for (int i = 0; i < voteExample.CandidateCount; i++)
                    {
                        _firstPreferences.Add(voteExample[i].Key, 0);
                    }

                    for (int i = 0; i < Votes.Count; i++)
                    {
                        var vote = Votes[i];
                        for (int j = 0; j < Votes[i].CandidateCount; j++)
                        {
                            if (vote[j].Value == 1)
                            {
                                _firstPreferences[vote[j].Key]++;
                            }
                        }
                    }
                }
            }
        }

        // TODO: handle situation where two or more candidates have the same number of votes
        public string GetMostPopularCandidate() =>
            _firstPreferences.OrderByDescending(pair => pair.Value).FirstOrDefault().Key;

        public string GetLeastPopularCandidate() =>
            _firstPreferences.OrderBy(pair => pair.Value).FirstOrDefault().Key;

        public bool HasWinner()
        {
            int votesToWin = VoteCount / 2 + 1;

            return CandidateCount == 1 || _firstPreferences.Any(pair => pair.Value >= votesToWin);
        }
    }
}
