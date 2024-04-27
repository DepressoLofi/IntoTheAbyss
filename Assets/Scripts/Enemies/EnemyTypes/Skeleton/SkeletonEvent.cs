using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEvent : MonoBehaviour
{
    public GameObject Skeleton;
    public GameObject vfx;
    public void MushroomDie()
    {
        var dieVfx = Instantiate(vfx, transform.position + transform.forward * -0.5f, Quaternion.Euler(Skeleton.transform.rotation.eulerAngles));
        Destroy(dieVfx, 0.6f);
        Destroy(Skeleton);
    }
}
