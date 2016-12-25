using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller<MainInstaller>
{
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
        Container.BindSignal<GameStartSignal>();
        Container.BindSignal<AddScoreSignal>();
    }
}