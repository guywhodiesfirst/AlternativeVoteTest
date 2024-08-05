using VoteSystems.Interfaces;
using VoteSystems.Results;

namespace VoteSystems.BaseClasses
{
    public abstract class BaseVotingSystem<TVoteArray> : IVotingSystem<TVoteArray>
    {
        public BaseVotingSystem() {}
        public abstract ConstituencyResult DefineWinnerInConstituency(TVoteArray voteArray);
    }
}