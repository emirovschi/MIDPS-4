using UnityEngine;

public class Obstacle : MonoBehaviour, IObstacle
{
    public void SetPosition(Vector3 position)
    {
        transform.Translate(position);
    }
}
