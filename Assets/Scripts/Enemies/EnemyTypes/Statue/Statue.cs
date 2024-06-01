using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    public float shootTime = 0.6f;
    private float timeToFire = 0f;

    void Update()
    {
        if (Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / shootTime;
            ShootProjectile();

        }
    }

    private void ShootProjectile()
    {
        ObjectPooler.Instance.SpawnFromPool("FireBall", shootPoint.position, shootPoint.rotation);
    }
}
