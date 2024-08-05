using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystems
{
    public class VoteArray
    {
        private List<Vote> _votes;
        private Dictionary<string, int> _firstPreferences;
        public int VoteCount => _votes.Count;
        public int CandidateCount => _votes[0].CandidateCount;
        public VoteArray()
        {
            _votes = new List<Vote>();
            _firstPreferences = new Dictionary<string, int>();
            SetFirstPreferences();
        }
        public VoteArray(List<Vote> votes)
        {
            _votes = votes;
            _firstPreferences = new Dictionary<string, int>();
            SetFirstPreferences();
            PrintFirstPreferences();
        }
        public void Add(Vote vote) 
        { 
            _votes.Add(vote);
            SetFirstPreferences();
        }
        public void PrintVotes()
        {
            int count = 1;
            foreach (var vote in _votes)
            {
                Console.WriteLine($"Vote {count}:");
                vote.Print();
                count++;
            }
        }

        public void PrintFirstPreferences()
        {
            foreach (var candidate in _firstPreferences)
            {
                Console.WriteLine($"{candidate.Key}: {candidate.Value}");
            }
        }

        public void EliminateCandidate(string candidateName)
        {
            if (string.IsNullOrEmpty(candidateName))
            {
            
                throw new ArgumentNullException(nameof(candidateName), "Candidate name cannot be null or empty.");
            }

            foreach (var vote in _votes)
            {
                vote.EliminateCandidate(candidateName);
            }
            SetFirstPreferences();
        }

        private void SetFirstPreferences()
        {
            var firstPreferences = new Dictionary<string, int>();
            var voteExample = _votes.FirstOrDefault();
            if (voteExample != null)
            {
                for (int i = 0; i < voteExample.CandidateCount; i++)
                {
                    firstPreferences.Add(voteExample[i].Key, 0);
                }
            }
            for (int i = 0; i <  _votes.Count; i++) 
            { 
                var vote = _votes[i];
                for(int j = 0; j < _votes[i].CandidateCount; j++) 
                {
                    if (vote[j].Value == 1)
                    {
                        firstPreferences[vote[j].Key]++;
                    }
                }
            }

            _firstPreferences = firstPreferences;
        }

        public string GetMostPopularCandidate() =>
            _firstPreferences.OrderByDescending(pair => pair.Value).FirstOrDefault().Key;

        public string GetLeastPopularCandidate() =>
            _firstPreferences.OrderBy(pair => pair.Value).FirstOrDefault().Key;

        public bool HasWinner()
        {
            int votesToWin = VoteCount / 2 + 1;

            return CandidateCount == 1 || (_firstPreferences.Any(pair => pair.Value >= votesToWin));
        }
    }
}
