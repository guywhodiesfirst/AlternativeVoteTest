using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystems.Results
{
    public class ConstituencyResult(List<string> log, string winner)
    {
        public List<string> Log { get; } = log;
        public string Winner { get; } = winner;
    }
}
