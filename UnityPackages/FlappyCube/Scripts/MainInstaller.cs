using ModestTree;
using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller<MainInstaller>
{
    public Player Player;
    public Killer[] Killers;

    public override void InstallBindings()
    {
        if (Application.isMobilePlatform)
        {
            Container.Bind<IControls>().To<TouchControls>().AsSingle();
        }
        else
        {
            Container.Bind<IControls>().To<KeyboardControls>().AsSingle();
        }

        Container.Bind<IGame>().To<Game>().AsSingle();
        Container.Bind<ITickable>().To<GameStarter>().AsSingle();
        Container.Bind<GameEnder>().NonLazy();
        Container.BindSignal<GameStartSignal>();
        Container.BindSignal<AddScoreSignal>();

        Container.Bind<ITickable>().To<PlayerController>().AsSingle();
        Container.BindAllInterfacesAndSelf<Player>().FromInstance(Player);
        
        Container.BindSignal<DeathSignal>();
        Killers.ForEach(k => AddKillerController(k));
    }

    private void AddKillerController(IKiller killer)
    {
        Container.Bind<KillerController>()
            .FromMethod(ctx => new KillerController(killer, ctx.Container.Resolve<DeathSignal>()))
            .NonLazy();
    }
}