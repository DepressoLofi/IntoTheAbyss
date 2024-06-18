using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UniqueMusic : MonoBehaviour
{
    private AudioSource bgmAudioSource;

    private readonly float fadeDuration = 1f;

    private float initialVolume;
    private float timer = 0f;

    public static UniqueMusic instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            bgmAudioSource = GetComponent<AudioSource>();
            initialVolume = bgmAudioSource.volume;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "RestingCutscene" && SceneManager.GetActiveScene().name != "RestingScene" && 
            SceneManager.GetActiveScene().name != "5-1_StickScene" && SceneManager.GetActiveScene().name != "5-2_EndScene")
        {
            Destroy(this.gameObject);
        }
    }
    public void FadeOutMusic()
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

        Destroy(this.gameObject);
        bgmAudioSource.volume = initialVolume;
    }


}
