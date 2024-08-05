using VoteSystems.Interfaces;

namespace VoteSystems.BaseClasses
{
    public abstract class BaseVote<T> : IVote<T>
    {
        public Dictionary<string, T> Bulletin { get; set; }
        public override string ToString()
        {
            string voteAsString = "";
            foreach (KeyValuePair<string, T> candidate in Bulletin)
            {
                voteAsString += $"{candidate.Key}: {candidate.Value}\n";
            }
            return voteAsString;
        }
        public KeyValuePair<string, T> this[int index]
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
