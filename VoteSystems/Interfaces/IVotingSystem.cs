using VoteSystems.Results;

namespace VoteSystems.Interfaces
{
    public interface IVotingSystem<TVoteArray>
    {
        ConstituencyResult DefineWinnerInConstituency(TVoteArray voteArray);
    }
}
