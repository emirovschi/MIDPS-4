using UnityEngine;

public abstract class View : MonoBehaviour, IView
{
    public bool Enabled
    {
        get
        {
            return gameObject.activeInHierarchy;
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}