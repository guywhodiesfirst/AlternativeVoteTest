using VoteSystems.Interfaces;

namespace VoteSystems.InstantRunoff
{
    public class InstantRunoffVote : IVote<Dictionary<string, int>>
    {
        public Dictionary<string, int> Bulletin { get; set; }
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

        public override string ToString()
        {
            string voteAsString = "";
            foreach (KeyValuePair<string, int> candidate in Bulletin)
            {
                voteAsString += $"{candidate.Key}: {candidate.Value}\n";
            }
            return voteAsString;
        }

        public KeyValuePair<string, int> this[int index]
        {
            get
            {
                if (index >= Bulletin.Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index out of range");
                }
                return Bulletin.ElementAt(index);
            }
        }
    }
}
