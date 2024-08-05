namespace VoteSystems.Interfaces
{
    public interface IVote<T>
    {
        T Bulletin { get; set; }
        string ToString();
    }
}
