using VoteSystems.BaseClasses;
using VoteSystems.Interfaces;

namespace VoteSystems.InstantRunoff
{
    public class InstantRunoffVote : BaseVote<int>
    {
        public int CandidateCount => Bulletin.Count;

        public InstantRunoffVote(Dictionary<string, int> bulletin)
        {
            Bulletin = bulletin;
        }

        public void EliminateCandidate(string candidateName)
        {
            if (Bulletin.ContainsKey(candidateName))
            {
                int candidateValue = Bulletin[candidateName];
                if (candidateValue > 0)
                {
                    var keys = Bulletin.Keys
                    .Where(key => key != candidateName && Bulletin[key] > candidateValue);

                    foreach (var key in keys)
                    {
                        Bulletin[key]--;
                    }
                }

                Bulletin.Remove(candidateName);
            }
        }
    }
}
