using UnityEngine;
using Zenject;

public class Killer : MonoBehaviour
{
    private Player player;
    private DeathSignal deathSignal;

    [Inject]
    public void Initialize(Player player, DeathSignal deathSignal)
    {
        this.player = player;
        this.deathSignal = deathSignal;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            deathSignal.Fire();
        }
    }
}
