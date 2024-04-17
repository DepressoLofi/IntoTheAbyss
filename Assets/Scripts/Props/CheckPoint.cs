using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private bool triggered;

    public Renderer rend;
    public Material litMaterial;

    void Start()
    {
        triggered = false;
    }
    private void LightUp()
    {
        if (rend != null && litMaterial != null) 
        {
            if(rend.materials.Length > 1) 
            {
                Material[] materials = rend.materials;
                materials[1] = litMaterial;
                rend.materials = materials;
            }
        }
    } 


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !triggered)
        {
            Puppy puppy = other.GetComponent<Puppy>();

            puppy.SetCheckpoint(transform.position);
            triggered = true;
            LightUp();
            SoundManager.PlaySound(SoundType.CHECKPOINT, 0.5f);

        }
    }


}
