using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed;
    public GameObject vfxPrefab;
    public GameObject hitPrefab;
    private void Start()
    {
        if (vfxPrefab != null)
        {
            var muzzleVFX = Instantiate(vfxPrefab, transform.position, Quaternion.identity);
            muzzleVFX.transform.forward = gameObject.transform.forward;
            Destroy(muzzleVFX, 0.8f);

        }
    }

    void Update()
    {
        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("No Speed");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        speed = 0;
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector2.up, contact.normal);
        Vector3 pos = contact.point;
        var psMuzzle = vfxPrefab.GetComponent<ParticleSystem>();

        if (hitPrefab != null)
        {
            var hitVFX = Instantiate(hitPrefab, pos, rot);
            SoundManager.PlaySound(SoundType.PUPPYSHOOTHIT, 1f);
            Destroy(hitVFX, 0.8f);
        }

        Destroy(gameObject);
    }
}
