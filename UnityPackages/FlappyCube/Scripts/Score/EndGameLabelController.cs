public class EndGameLabelController : Controller<IEndGameLabel>
{
    public EndGameLabelController(IEndGameLabel view) : base(view)
    {
    }

    public void SetScore(int score, int highScore)
    {
        View.SetScore(score, highScore);
        View.Show();
    }
}
