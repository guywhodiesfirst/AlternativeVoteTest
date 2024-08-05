using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystems.Interfaces
{
    public interface IVote<T>
    {
        T Bulletin { get; set; }
        string ToString();
    }
}
