using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private bool triggered;
    [SerializeField] private Light lightComponent;

    public Renderer rend;
    public Material litMaterial;

    void Start()
    {
        if(lightComponent != null)
        {
            lightComponent.enabled = false;
        }
        
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
            if (lightComponent != null)
            {
                lightComponent.enabled = true;
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
            SoundManager.PlaySound(SoundType.CHECKPOINT, 0.25f);

        }
    }


}
