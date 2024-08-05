using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystems.Interfaces
{
    public interface IVotingSystem<TVoteArray>
    {
        string DefineWinner(TVoteArray voteArray);
    }
}
