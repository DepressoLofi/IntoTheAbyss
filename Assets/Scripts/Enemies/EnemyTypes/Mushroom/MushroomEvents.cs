using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomEvents : MonoBehaviour
{
    public GameObject Mushroom;
    public GameObject vfx;
    public void MushroomDie()
    {      
        var dieVfx = Instantiate(vfx, Mushroom.transform.position, Quaternion.Euler(Mushroom.transform.rotation.eulerAngles));
        Destroy(dieVfx, 0.6f);
        Destroy(Mushroom);
    }
}
