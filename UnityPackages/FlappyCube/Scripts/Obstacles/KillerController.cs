public class KillerController
{
    public KillerController(IKiller killer, DeathSignal deathSignal)
    {
        killer.OnTouch += () => deathSignal.Fire(killer);
    }
}
