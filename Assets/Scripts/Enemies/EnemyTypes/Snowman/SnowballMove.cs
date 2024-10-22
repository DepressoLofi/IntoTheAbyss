using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SnowballMove : MonoBehaviour, IPooledObject
{
    public float speed;
    private float runSpeed;
    public GameObject vfxPrefab;

    public float lifetime = 2.0f;
    private float timer = 0.0f;

    public void OnObjectSpawn()
    {
        if (vfxPrefab != null)
        {
            var muzzleVFX = Instantiate(vfxPrefab, transform.position, Quaternion.identity);
            muzzleVFX.transform.forward = gameObject.transform.forward;
            Destroy(muzzleVFX, 0.8f);
        }
        timer = 0f;
        runSpeed = speed;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= lifetime)
        {
            gameObject.SetActive(false);
        }

    }

    void FixedUpdate()
    {
        if (runSpeed != 0)
        {
            transform.position += transform.forward * (runSpeed * Time.deltaTime);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        runSpeed = 0;
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector2.up, contact.normal);
        Vector3 pos = contact.point;
        var psMuzzle = vfxPrefab.GetComponent<ParticleSystem>();

        if (vfxPrefab != null)
        {
            var hitVFX = Instantiate(vfxPrefab, pos, rot);
            //TO-DO to add sfx
            Destroy(hitVFX, 0.8f);
        }
        gameObject.SetActive(false);

    }

}
