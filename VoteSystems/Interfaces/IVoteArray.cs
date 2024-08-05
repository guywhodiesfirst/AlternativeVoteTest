using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystems.Interfaces
{
    public interface IVoteArray<TCollection, TVote>
    {
        TCollection Votes { get; set; }
        void Add(TVote vote);
        string ToString();
        string GetMostPopularCandidate();
        string GetLeastPopularCandidate();
    }
}
