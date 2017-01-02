using UnityEngine;

public class Player : View, IPlayer
{
    public float JumpForce = 15;
    public float TorqueForce = 10;

    public void Unfreeze()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
    }

    public void Jump()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        GetComponent<Rigidbody>().AddTorque(Vector3.back * TorqueForce);
    }
}
