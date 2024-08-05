namespace VoteSystems.Interfaces
{
    public interface IVote<T>
    {
        Dictionary<string, T> Bulletin { get; set; }
        string ToString();
    }
}
