using UnityEngine;

public interface IObstacle : IView
{
    void SetParent(GameObject buffer);

    void SetPosition(Vector3 position);

    void Move(float distance);

    float GetPosition();
}
