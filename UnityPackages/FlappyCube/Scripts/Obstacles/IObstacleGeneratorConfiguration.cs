using UnityEngine;

public interface IObstacleGeneratorConfiguration
{
    int Layer { get; }
    float PastDistance { get; }
    int TotalObstacles { get; }
    int StartDistance { get; }
    GameObject Buffer { get; }
}
