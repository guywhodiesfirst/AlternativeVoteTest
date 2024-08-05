using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlternativeVoteTest
{
    public static class AlternativeVote
    {
        public static string DefineWinner(VoteArray votes) 
        {
            while (!votes.HasWinner()) 
            {
                votes.PrintFirstPreferences();
                string candidateToEliminate = votes.GetLeastPopularCandidate();
                Console.WriteLine($"Candidate to eliminate: {candidateToEliminate}");
                votes.EliminateCandidate(candidateToEliminate);
                Console.WriteLine();
            }

            votes.PrintFirstPreferences();
            Console.WriteLine($"Winner: {votes.GetMostPopularCandidate()}");
            return votes.GetMostPopularCandidate();
        }
    }
}
