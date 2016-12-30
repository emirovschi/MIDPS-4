using System;
using UnityEngine.SceneManagement;

public class GameEnder : IDisposable
{
    private readonly DeathSignal deathSignal;

    public GameEnder(DeathSignal deathSignal)
    {
        this.deathSignal = deathSignal + Restart;
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Dispose()
    {
        deathSignal.Unlisten(Restart);
    }
}
