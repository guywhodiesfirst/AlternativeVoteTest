using System.Security.Cryptography;
using VoteSystems.InstantRunoff;

namespace VoteSystems
{
    public class SeedArray
    {
        private readonly string[] _candidates = new string[] 
        {
            "Alice (Conservative)", 
            "Bob (Liberal)", 
            "Senya (Social-democrat)", 
            "Maria (Green)", 
            "Boris (Identity)", 
            "Vitalii (Communist)"
        };
        public void Seed(InstantRunoffVoteArray votes, int numOfVotes)
        {
            for(int i = 0; i < numOfVotes; i++)
            {
                votes.Add(GenerateRandomVote());
            }
        }

        // TODO: add parties class:
        // left-wing voters lean to vote for other left-wing parties and vice-versa
        private InstantRunoffVote GenerateRandomVote()
        {
            var preferences = new int[_candidates.Length];
            int count = RandomNumberGenerator.GetInt32(3) + 3;
            int index = GetRandomIndex();
            while (count > 0) 
            {
                while (preferences[index] != 0) 
                { 
                    index = GetRandomIndex();
                }
                preferences[index] = count;
                count--;
            }

            var voteDictionary = new Dictionary<string, int>();
            for (int i = 0; i < _candidates.Length; i++)
            {
                voteDictionary.Add(_candidates[i], preferences[i]);
            }

            return new InstantRunoffVote(voteDictionary);
        }
        private int GetRandomIndex()
        {
            return RandomNumberGenerator.GetInt32(_candidates.Length);
        }
    }
}