using System;
using Zenject;

public class PlayerController : Controller<IPlayer>, ITickable, IDisposable
{
    private readonly IControls controls;
    private readonly GameStartSignal gameStartSignal;

    public PlayerController(IPlayer view, IControls controls, GameStartSignal gameStartSignal) : base(view)
    {
        this.controls = controls;
        this.gameStartSignal = gameStartSignal + View.Unfreeze;
    }

    public void Tick()
    {
        if (controls.IsAction())
        {
            View.Jump();
        }
    }

    public void Dispose()
    {
        gameStartSignal.Unlisten(View.Unfreeze);
    }
}
