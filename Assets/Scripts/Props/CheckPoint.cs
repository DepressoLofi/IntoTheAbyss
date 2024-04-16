using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private bool triggered;

    void Start()
    {
        triggered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !triggered)
        {
            Puppy puppy = other.GetComponent<Puppy>();

            puppy.SetCheckpoint(transform.position);
            triggered = true;
            SoundManager.PlaySound(SoundType.CHECKPOINT, 0.5f);

        }
    }


}
