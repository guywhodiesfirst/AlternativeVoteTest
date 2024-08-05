using VoteSystems.BaseClasses;

namespace VoteSystems.FPTP
{
    public class FPTPVoteArray : BaseVoteArray<FPTPVote>
    {
        protected override void SetFirstPreferences()
        {
            if (Votes.Count > 0)
            {
                var firstVote = Votes.First();
                var candidates = firstVote.Bulletin.Select(c => c.Key).Distinct();

                for (int i = 0; i < Votes.Count; i++)
                {
                    var key = Votes[i].Bulletin.First(pair => pair.Value == true).Key;
                    FirstPreferences[key]++;
                }
            }
        }
    }
}
