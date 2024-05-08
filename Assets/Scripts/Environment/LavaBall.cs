using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBall : MonoBehaviour
{

    [SerializeField] private float force;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (transform.localPosition.y <= 0)
        {
            StartCoroutine(FreezeAndJump());
        }

    }

    void Jump()
    {
        rb.velocity = Vector3.up * force;
    }

    IEnumerator FreezeAndJump()
    {
        rb.constraints |= RigidbodyConstraints.FreezePositionY;
        yield return Helpers.GetWait(1f);

        rb.constraints &= ~(RigidbodyConstraints.FreezePositionY);
        Jump();
    }
}
