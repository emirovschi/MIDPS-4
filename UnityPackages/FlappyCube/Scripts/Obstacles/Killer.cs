using System;
using UnityEngine;
using Zenject;

public class Killer : MonoBehaviour, IKiller
{
    public event Action OnTouch = delegate {};

    private Player player;

    [Inject]
    public void Initialize(Player player)
    {
        this.player = player;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            OnTouch();
        }
    }
}
