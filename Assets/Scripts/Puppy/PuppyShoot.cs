using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyShoot : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject effectToSpawn;
    public float fireRate;

    private float timeToFire = 0;


    void Update()
    {
        if (GameStateManager.Instance.canInput && GameStateManager.Instance.havePower)
        {
            if (Input.GetKeyDown(KeyCode.X) && Time.time >= timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                SpawnVFX();
            }
        }

    }

    void SpawnVFX()
    {
        GameObject vfx;
        if (shootPoint != null)
        {
            vfx = Instantiate(effectToSpawn, shootPoint.position, shootPoint.rotation);
            Destroy(vfx, 1f);

        }
    }

}
