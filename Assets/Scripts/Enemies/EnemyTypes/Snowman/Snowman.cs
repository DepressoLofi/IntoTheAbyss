using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowman : MonoBehaviour
{
    public SnowmanData data;
    [SerializeField] Transform shootPoint;
    private float timeToFire = 0f;

    private int hp;


    void Start()
    {
        hp = data.hitPoint;
    }

    void Update()
    {
        if (Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / data.shootTime;
            ShootProjectile();
            
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Damaged();
        }
    }

    private void Damaged()
    {
        hp -= 1;
        if(hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        var dieVfx = Instantiate(data.diePrefab, transform.position, transform.rotation);
        
        Destroy(dieVfx, 0.8f);
        Destroy(gameObject);
    }

    private void ShootProjectile()
    {
        ObjectPooler.Instance.SpawnFromPool("SnowBall", shootPoint.position, shootPoint.rotation);
    }
}
