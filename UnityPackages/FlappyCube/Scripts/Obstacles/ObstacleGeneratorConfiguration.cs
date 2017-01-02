using UnityEngine;

public class ObstacleGeneratorConfiguration : MonoBehaviour, IObstacleGeneratorConfiguration
{
    [SerializeField]
    private int layer;

    [SerializeField]
    private float pastDistance;

    [SerializeField]
    private int totalObstacles;

    [SerializeField]
    private GameObject buffer;

    public int Layer
    {
        get
        {
            return layer;
        }
    }

    public float PastDistance
    {
        get
        {
            return pastDistance;
        }
    }

    public int TotalObstacles
    {
        get
        {
            return totalObstacles;
        }
    }

    public GameObject Buffer
    {
        get
        {
            return buffer;
        }
    }
}
