using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlternativeVoteTest
{
    public class Vote
    {
        private Dictionary<string, int> _preferences;
        public int CandidateCount => _preferences.Count;
        public Vote(Dictionary<string, int> preferences)
        {
            _preferences = preferences;
        }

        public void EliminateCandidate(string candidateName)
        {
            if (_preferences.ContainsKey(candidateName)) { 
                int value = _preferences[candidateName];
                var keys = _preferences.Keys.ToList();

                foreach (var key in keys) 
                { 
                    if(key != candidateName)
                    {
                        if (value > 0 && _preferences[key] > value)
                            _preferences[key]--;
                    }
                }

                _preferences.Remove(candidateName);
            }
        }

        public void Print()
        {
            foreach (KeyValuePair<string, int> candidate in _preferences) 
            {
                Console.WriteLine($"{candidate.Key}: {candidate.Value}");
            }
            Console.WriteLine();
        }

        public KeyValuePair<string, int> this[int index]
        {
            get
            {
                if (index >= _preferences.Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index out of range");
                }
                return _preferences.ElementAt(index);
            }
        }
    }
}
