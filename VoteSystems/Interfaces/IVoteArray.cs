using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystems.Interfaces
{
    public interface IVoteArray<TVote>
    {
        List<TVote> Votes { get; set; }
        Dictionary<string, int> FirstPreferences { get; }
        void Add(TVote vote);
        string FirstPreferencesToString();
        string GetMostPopularCandidate();
        string GetLeastPopularCandidate();
    }
}
