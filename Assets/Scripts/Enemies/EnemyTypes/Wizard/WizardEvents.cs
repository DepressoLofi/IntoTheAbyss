using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardEvents : MonoBehaviour
{
    public GameObject Wizard;
    public GameObject vfx;

    public Transform shootPoint;
    public GameObject fireVfx;
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

        GameObject startVfx;
        startVfx = Instantiate(fireVfx, shootPoint.position, shootPoint.rotation);
        Destroy(startVfx, 1.7f);

    }
}
