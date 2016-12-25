using Zenject;

public class GameStarter : ITickable
{
    private readonly IGame game;
    private readonly IControls controls;

    public GameStarter(IGame game, IControls controls)
    {
        this.game = game;
        this.controls = controls;
    }

    public void Tick()
    {
        if (!game.IsStarted && controls.IsAction())
        {
            game.Start();
        }
    }
}
