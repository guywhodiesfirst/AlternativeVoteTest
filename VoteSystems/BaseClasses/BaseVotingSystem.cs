using VoteSystems.Interfaces;

namespace VoteSystems.BaseClasses
{
    public abstract class BaseVotingSystem<TVoteArray> : IVotingSystem<TVoteArray>
    {
        public BaseVotingSystem() {}
        public abstract string DefineWinner(TVoteArray voteArray);
    }
}