using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSFX : MonoBehaviour
{
    public AudioSource audioSrc;
    public AudioClip hoverSfx;
    public AudioClip clickedSfx;
    public void HoverSound()
    {
        audioSrc.PlayOneShot(hoverSfx);
    }

    public void ClickSound()
    {
        audioSrc.PlayOneShot(clickedSfx);
    }

}
