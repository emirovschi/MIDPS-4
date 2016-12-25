using UnityEngine;

public class KeyboardControls : IControls
{
    public bool IsAction()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
