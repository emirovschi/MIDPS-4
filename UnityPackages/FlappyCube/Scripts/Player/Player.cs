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

    public void Fracture()
    {
        Vector3 force = GetComponent<Rigidbody>().velocity + new Vector3(5, 0, 0);
        System.Random random = new System.Random();

        for (int i = 0; i < transform.childCount; i++)
        {
            Vector3 randomForce = new Vector3((float) random.NextDouble(),
                (float) random.NextDouble(), (float) random.NextDouble());

            GameObject child = transform.GetChild(i).gameObject;
            child.SetActive(true);

            child.GetComponent<Rigidbody>().AddForce(force + randomForce, ForceMode.Impulse);
        }

        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Renderer>().enabled = false;
        GetComponent<Rigidbody>().Sleep();
    }
}
