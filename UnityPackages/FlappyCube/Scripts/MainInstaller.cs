using System.Linq;
using ModestTree;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

public class MainInstaller : MonoInstaller<MainInstaller>
{
    public Player Player;
    public Object Obstacle;
    public ScoreLabel ScoreLabel;
    public EndGameLabel EndGameLabel;
    public ObstacleGeneratorConfiguration[] ObstacleGenerators;

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
        Container.BindAllInterfaces<GameEnder>().To<GameEnder>().AsSingle();
        Container.BindSignal<GameStartSignal>();
        Container.BindSignal<AddScoreSignal>();

        Container.BindAllInterfacesAndSelf<Player>().FromInstance(Player);
        Container.BindAllInterfacesAndSelf<PlayerController>().To<PlayerController>().AsSingle();
        
        Container.BindSignal<DeathSignal>();

        Container.Bind<IObstacle>().FromPrefab(Obstacle).WhenInjectedInto<ObstacleController>();
        Container.BindFactory<ObstacleController, ControllerFactory<ObstacleController, IObstacle>>();

        Container.Bind<IPool<ObstacleController, IObstacle>>().To<Pool<ObstacleController, IObstacle>>().AsSingle();

        Enumerable.Range(0, ObstacleGenerators.Length).ForEach(i => AddGenerator(i, ObstacleGenerators[i]));

        Container.BindAllInterfacesAndSelf<ScoreLabel>().FromInstance(ScoreLabel);
        Container.BindAllInterfacesAndSelf<ScoreLabelController>().To<ScoreLabelController>().AsSingle();

        Container.BindAllInterfacesAndSelf<EndGameLabel>().FromInstance(EndGameLabel);
        Container.BindAllInterfacesAndSelf<EndGameLabelController>().To<EndGameLabelController>().AsSingle();
    }

    private void AddGenerator(int index, ObstacleGeneratorConfiguration configuration)
    {
        string id = "obstacleGenerator" + index;
        Container.Bind<ITickable>().To<ObstacleGenerator>().AsSingle(id);
        Container.Bind<IObstacleGeneratorConfiguration>()
            .FromInstance(configuration)
            .When(c => c.ConcreteIdentifier.ToString().Equals(id));
    }
}
