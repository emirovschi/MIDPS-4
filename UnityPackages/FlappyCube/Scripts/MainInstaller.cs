using System;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

public class MainInstaller : MonoInstaller<MainInstaller>
{
    public Player Player;
    public Object Obstacle;

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

        Container.BindAllInterfaces<Game>().To<Game>().AsSingle();
        Container.Bind<ITickable>().To<GameStarter>().AsSingle();
        Container.Bind<IDisposable>().To<GameEnder>().AsSingle();
        Container.BindSignal<GameStartSignal>();
        Container.BindSignal<AddScoreSignal>();

        Container.BindAllInterfacesAndSelf<Player>().FromInstance(Player);
        Container.BindAllInterfaces<PlayerController>().To<PlayerController>().AsSingle();
        
        Container.BindSignal<DeathSignal>();
    }
}
