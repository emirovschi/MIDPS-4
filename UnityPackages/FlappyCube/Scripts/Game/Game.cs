public class Game : IGame
{
    private bool isStarted;
    private int score;

    public bool IsStarted
    {
        get
        {
            return isStarted;
        }
    }

    public void Start()
    {
        isStarted = true;
    }

    public int Score
    {
        get
        {
            return score;
        }
    }

    public void AddScore()
    {
        score++;
    }
}
