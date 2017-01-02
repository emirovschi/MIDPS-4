using System.Collections.Generic;
using ModestTree;
using UnityEngine;
using Zenject;
using Random = System.Random;

public class ObstacleGenerator : ITickable
{
    private readonly IPool<ObstacleController, IObstacle> pool;
    private readonly IGame game;
    private readonly IObstacleGeneratorConfiguration configuration;
    private readonly Queue<ObstacleController> obstacles;
    private readonly Random random;
    private int spawnedObstacles;

    public ObstacleGenerator(IPool<ObstacleController, IObstacle> pool, IGame game,
        IObstacleGeneratorConfiguration configuration)
    {
        this.pool = pool;
        this.game = game;
        this.configuration = configuration;
        spawnedObstacles = configuration.StartDistance;
        obstacles = new Queue<ObstacleController>();
        random = new Random();
    }

    public void Tick()
    {
        RemovePastObstacles();
        MoveObstacles();
        AddNewObstacles();
    }

    private void RemovePastObstacles()
    {
        while (obstacles.Count > 0 && obstacles.Peek().GetPosition() < game.Distance - configuration.PastDistance)
        {
            pool.Delete(obstacles.Dequeue());
        }
    }

    private void MoveObstacles()
    {
        obstacles.ForEach(o => o.Move());
    }

    private void AddNewObstacles()
    {
        for (int i = obstacles.Count; i < configuration.TotalObstacles; i++)
        {
            ObstacleController obstacle = pool.Create();
            obstacle.Init(configuration.Buffer, configuration.Layer, spawnedObstacles++, (float) random.NextDouble() - 0.5f);
            obstacles.Enqueue(obstacle);
        }
    }
}
