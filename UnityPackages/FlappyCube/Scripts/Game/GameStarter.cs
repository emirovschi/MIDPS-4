using Zenject;

public class GameStarter : ITickable
{
    private readonly IGame game;
    private readonly IControls controls;
    private readonly GameStartSignal gameStartSignal;

    public GameStarter(IGame game, IControls controls, GameStartSignal gameStartSignal)
    {
        this.game = game;
        this.controls = controls;
        this.gameStartSignal = gameStartSignal;
    }

    public void Tick()
    {
        if (!game.IsStarted && controls.IsAction())
        {
            gameStartSignal.Fire();
        }
    }
}
