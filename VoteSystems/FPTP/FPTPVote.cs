using VoteSystems.BaseClasses;

namespace VoteSystems.FPTP
{
    public class FPTPVote : BaseVote<bool>
    {
        public FPTPVote(string[] allCandidates, string candidateToVote)
        {
            if(allCandidates.Contains(candidateToVote))
            {
                Bulletin = new Dictionary<string, bool>();
                foreach(string candidate in allCandidates) 
                { 
                    if(candidate == candidateToVote) 
                    { 
                        Bulletin.Add(candidate, true);
                    }
                    else
                    {
                        Bulletin.Add(candidate, false);
                    }
                }
            }
        }
    }
}
