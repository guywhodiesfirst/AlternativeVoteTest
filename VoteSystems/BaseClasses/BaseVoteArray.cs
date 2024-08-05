using VoteSystems.Interfaces;

namespace VoteSystems.BaseClasses
{
    public abstract class BaseVoteArray<TVote> : IVoteArray<TVote>
    {
        public List<TVote> Votes { get; set; }
        public Dictionary<string, int> FirstPreferences { get; }
        public BaseVoteArray()
        {
            Votes = new List<TVote>();
            FirstPreferences = new Dictionary<string, int>();
        }
        public BaseVoteArray(BaseVoteArray<TVote> other)
        {
            Votes = new List<TVote>(other.Votes);
            FirstPreferences = new Dictionary<string, int>(other.FirstPreferences);
        }

        public void Add(TVote vote)
        {
            Votes.Add(vote);
            SetFirstPreferences();
        }
        public string FirstPreferencesToString()
        {
            string firstPreferencesAsString = "";
            foreach (var candidate in FirstPreferences)
            {
                firstPreferencesAsString += $"{candidate.Key}: {candidate.Value}\n";
            }
            return firstPreferencesAsString;
        }
        
        // TODO: handle situation where two or more candidates have the same number of votes
        public string GetMostPopularCandidate() =>
            FirstPreferences.OrderByDescending(pair => pair.Value).FirstOrDefault().Key;
        public string GetLeastPopularCandidate() =>
            FirstPreferences.OrderBy(pair => pair.Value).FirstOrDefault().Key;

        protected abstract void SetFirstPreferences();
    }
}