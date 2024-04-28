using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardEvents : MonoBehaviour
{
    public GameObject Wizard;
    public GameObject vfx;

    public Transform shootPoint;
    private AudioSource fireSfx;

    private void Start()
    {
        fireSfx = GetComponent<AudioSource>();
    }

    public void Die()
    {
        var dieVfx = Instantiate(vfx, transform.position + transform.forward * -1f, Quaternion.Euler(Wizard.transform.rotation.eulerAngles));
        Destroy(dieVfx, 0.6f);
        Destroy(Wizard);
    }

    public void Shoot()
    {
        fireSfx.Play();
        ObjectPooler.Instance.SpawnFromPool("FireBall", shootPoint.position, shootPoint.rotation);
    }
}
