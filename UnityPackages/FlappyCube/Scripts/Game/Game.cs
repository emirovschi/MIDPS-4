using System;public class Game : IGame, IDisposable
{
    private readonly GameStartSignal gameStartSignal;
    private readonly AddScoreSignal addScoreSignal;

    private bool isStarted;
    private int score;

    public bool IsStarted
    {
        get
        {
            return isStarted;
        }
    }

    public int Score
    {
        get
        {
            return score;
        }
    }
    
    public Game(GameStartSignal gameStartSignal, AddScoreSignal addScoreSignal)
    {
        this.gameStartSignal = gameStartSignal + Start;
        this.addScoreSignal = addScoreSignal + AddScore;
    }

    private void Start()
    {
        isStarted = true;
    }

    private void AddScore()
    {
        score++;
    }

    public void Dispose()
    {
        gameStartSignal.Unlisten(Start);
        addScoreSignal.Unlisten(AddScore);
    }
}
