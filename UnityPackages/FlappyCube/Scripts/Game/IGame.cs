public interface IGame
{
    bool IsStarted { get; }

    void Start();

    int Score { get; }

    void AddScore();
}