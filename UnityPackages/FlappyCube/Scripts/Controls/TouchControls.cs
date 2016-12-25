using System.Linq;
using UnityEngine;

public class TouchControls : IControls
{
    public bool IsAction()
    {
        return Enumerable.Range(0, Input.touchCount)
            .Select(i => Input.GetTouch(i))
            .Any(t => t.phase == TouchPhase.Began);
    }
}
