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
        SoundManager.PlaySound(SoundType.POOF, 0.4f);
        Destroy(dieVfx, 0.6f);
        Destroy(Mushroom);
    }
}
