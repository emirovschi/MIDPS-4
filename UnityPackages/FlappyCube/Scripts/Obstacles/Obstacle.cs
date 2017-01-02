using UnityEngine;

public class Obstacle : View, IObstacle
{
    public void SetParent(GameObject buffer)
    {
        transform.parent = buffer.transform;
    }

    public void SetPosition(Vector3 position)
    {
        transform.transform.position = position;
    }

    public void Move(float distance)
    {
        transform.position = new Vector3(distance, transform.position.y, transform.position.z);
    }

    public float GetPosition()
    {
        return transform.position.x;
    }
}
