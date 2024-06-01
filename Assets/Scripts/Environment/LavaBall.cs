using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBall : MonoBehaviour
{

    [SerializeField] private float force;
    [SerializeField] private float delayTime = 1f;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints |= RigidbodyConstraints.FreezePositionY;
        StartCoroutine(FirstJump(delayTime));

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

    IEnumerator FirstJump(float delayTime)
    {
        
        yield return Helpers.GetWait(delayTime);
        rb.constraints &= ~(RigidbodyConstraints.FreezePositionY);
        Jump();

    }

    IEnumerator FreezeAndJump()
    {
        rb.constraints |= RigidbodyConstraints.FreezePositionY;
        yield return Helpers.GetWait(1f);

        rb.constraints &= ~(RigidbodyConstraints.FreezePositionY);
        Jump();
    }
}
