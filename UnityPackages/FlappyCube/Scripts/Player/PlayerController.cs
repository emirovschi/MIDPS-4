using System;
using Zenject;

public class PlayerController : ITickable, IDisposable
{
    private IPlayer player;
    private IControls controls;
    private GameStartSignal gameStartSignal;

    [Inject]
    public void Initialize(IPlayer player, IControls controls, GameStartSignal gameStartSignal)
    {
        this.player = player;
        this.controls = controls;
        this.gameStartSignal = gameStartSignal + player.Unfreeze;
    }

    public void Tick()
    {
        if (controls.IsAction())
        {
            player.Jump();
        }
    }

    public void Dispose()
    {
        gameStartSignal -= player.Unfreeze;
    }
}
