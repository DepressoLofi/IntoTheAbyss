using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMusic : MonoBehaviour
{
    private AudioSource bgmAudioSource;
    private float timer = 0f;
    private readonly float fadeDuration = 1f;

    void Awake()
    {
        bgmAudioSource = GetComponent<AudioSource>();
    }

    public void Fade()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float startTime = Time.time;
        float startVolume = bgmAudioSource.volume;

        while (Time.time < startTime + fadeDuration)
        {
            timer = (Time.time - startTime) / fadeDuration;
            bgmAudioSource.volume = Mathf.Lerp(startVolume, 0.0f, timer);
            yield return null;
        }

        bgmAudioSource.volume = 0f;


    }
}
