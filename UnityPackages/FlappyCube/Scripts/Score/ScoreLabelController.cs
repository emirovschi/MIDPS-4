using System;

public class ScoreLabelController : Controller<IScoreLabel>, IDisposable
{
    private readonly IGame game;
    private readonly AddScoreSignal addScoreSignal;

    public ScoreLabelController(IScoreLabel view, IGame game, AddScoreSignal addScoreSignal) : base(view)
    {
        this.game = game;
        this.addScoreSignal = addScoreSignal + SetScore;
    }

    private void SetScore()
    {
        View.SetScore(game.Score.ToString());
    }

    public void Dispose()
    {
        addScoreSignal.Unlisten(SetScore);
    }
}
