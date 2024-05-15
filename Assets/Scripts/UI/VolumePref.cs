using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumePref : MonoBehaviour
{

    public AudioMixer audioMixer;
    private const string bgmKey = "bgm";
    private const string sfxKey = "sfx";

    void Start()
    {
        if (PlayerPrefs.HasKey(bgmKey))
        {
            float savedBgm = PlayerPrefs.GetFloat(bgmKey);
            SetBgm(savedBgm);
        }
        else
        {
            SetBgm(0f);
        }
        if (PlayerPrefs.HasKey(sfxKey))
        {
            float savedSfx = PlayerPrefs.GetFloat(sfxKey);
            SetSfx(savedSfx);
        }
        else
        {
            SetSfx(0f);
        }
    }

    public void SetBgm(float volume)
    {
        audioMixer.SetFloat("bgm", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(bgmKey, volume);
        PlayerPrefs.Save();
    }

    public void SetSfx(float volume)
    {
        audioMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(sfxKey, volume);
        PlayerPrefs.Save();
    }
}
