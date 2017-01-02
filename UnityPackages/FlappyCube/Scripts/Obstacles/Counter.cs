using UnityEngine;
using Zenject;

public class Counter : MonoBehaviour
{
    private Player player;
    private AddScoreSignal addScoreSignal;

    [Inject]
    public void Initialize(Player player, AddScoreSignal addScoreSignal)
    {
        this.player = player;
        this.addScoreSignal = addScoreSignal;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == player.gameObject)
        {
            addScoreSignal.Fire();
        }
    }
}
