using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class BoyThrow : MonoBehaviour
{
    [SerializeField] private GameObject stick;
    [SerializeField] private float throwForce = 10f;

    public void Throw()
    {
        GameObject stickInstance = Instantiate(stick, transform.position, transform.rotation);
        Rigidbody stickRigidbody = stickInstance.GetComponent<Rigidbody>();

        if (stickRigidbody != null)
        {

            stickRigidbody.AddForce(Vector3.forward * throwForce, ForceMode.Impulse);
        }
        Destroy(stickInstance, 3f);
    }

}
